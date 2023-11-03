using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HJTB.Server
{
	public class Startup 
	{
		public const string AdminCorsPolicy = "_ADMIN_CORS_POLICY";
		public const string OthersCorsPolicy = "_OTHERS_CORS_POLICY";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices
			(IServiceCollection services)
		{
			// Cross-Origin Resource Sharing (CORS)
			services.AddCors(options =>
			{
				options.AddPolicy(AdminCorsPolicy,
					builder =>
					{
						builder
							.WithOrigins("http://localhost:5001")
							.AllowAnyHeader()
							.AllowAnyMethod()
							//.AllowCredentials()
							;
					});

				options.AddPolicy(OthersCorsPolicy,
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyHeader()
							.AllowAnyMethod()
							//.AllowCredentials()
							;
					});
			});

			//services.AddControllers();

			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.MaxDepth = 5;
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
			});

			//services.AddDbContext<Data.DatabaseContext>(options =>
			//{
			//	options.UseSqlServer
			//		(connectionString: "Password=1234512345;Persist Security Info=True;User ID=SA;Initial Catalog=HjxSecurity;Data Source=.");
			//});

			//services.AddDbContext<Data.DatabaseContext>(options =>
			//{
			//	options.UseSqlServer
			//		(connectionString: Configuration.GetSection(key: "ConnectionStrings").GetSection(key: "MyConnectionString");
			//});

			//services.AddTransient<Data.IUnitOfWork, Data.UnitOfWork>();

			services.AddTransient<Data.IUnitOfWork, Data.UnitOfWork>(sp =>
			{
				Data.Tools.Options options =
					new Data.Tools.Options
					{
						Provider =
							(Data.Tools.Enums.Provider)
							System.Convert.ToInt32(Configuration.GetSection(key: "databaseProvider").Value),

						//using Microsoft.EntityFrameworkCore;
						//ConnectionString =
						//	Configuration.GetConnectionString().GetSection(key: "MyConnectionString").Value,

						ConnectionString =
							Configuration.GetSection(key: "ConnectionStrings").GetSection(key: "MyConnectionString").Value,
					};

				return new Data.UnitOfWork(options: options);
			});

			//services.AddTransient<Hjx.ILogger, Hjx.Logger>();
		}

		public void Configure
			(IApplicationBuilder app,
			IWebHostEnvironment env)
		{
			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//}
			//else
			//{
			//	app.UseExceptionHandler("/Error");
			//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			//	app.UseHsts();
			//}

			//app.UseHttpsRedirection();

			app.UseCors(policyName: AdminCorsPolicy);

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
