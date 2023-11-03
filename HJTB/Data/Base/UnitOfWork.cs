using Data.Tools;
using Data.Tools.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Base
{
	public abstract class UnitOfWork : IUnitOfWork
	{

		public UnitOfWork(Options options) : base()
		{
			Options = options;
		}
		
		protected Options Options { get; set; }
		
		private DatabaseContext _databaseContext;

		internal DatabaseContext DatabaseContext
		{
			get
			{
				if (_databaseContext == null)
				{
					var optionsBuilder =
						new DbContextOptionsBuilder<DatabaseContext>();

					switch (Options.Provider)
					{
						case Provider.SqlServer:
						{
							optionsBuilder.UseSqlServer
								(connectionString: Options.ConnectionString);

							break;
						}

						case Provider.MySql:
						{
							//optionsBuilder.UseMySql
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Provider.Oracle:
						{
							//optionsBuilder.UseOracle
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Provider.PostgreSQL:
						{
							//optionsBuilder.UsePostgreSQL
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Provider.InMemory:
						{
							optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

							break;
						}

						default:
						{
							break;
						}
					}

					_databaseContext =
						new DatabaseContext(options: optionsBuilder.Options);
				}

				return _databaseContext;
			}
		}

		Repository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(databaseContext: DatabaseContext);
		}

		public virtual void Save()
		{
			DatabaseContext.SaveChanges();
		}

		public virtual async Task SaveAsync()
		{
			await DatabaseContext.SaveChangesAsync();
		}

		public bool IsDisposed { get; protected set; }

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (disposing)
			{
				// TODO: dispose managed state (managed objects).

				if (_databaseContext != null)
				{
					_databaseContext.Dispose();
					_databaseContext = null;
				}
			}

			IsDisposed = true;
		}

		~UnitOfWork()
		{
			Dispose(false);
		}
	}
}
