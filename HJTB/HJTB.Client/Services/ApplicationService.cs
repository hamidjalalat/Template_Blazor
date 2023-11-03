using Hjx;
using Infrastructure;
using Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ViewModels.Applications;

namespace HJTB.Client.Services
{
	public class ApplicationService : BaseService
	{
		public ApplicationService(HttpClient client) : base(client)
		{
		}

		protected override string GetApiUrl()
		{
			return "applications";
		}

		public async Task<IList<Application>>GetAsync()
		{
			var result =await GetAsync<IList<Application>>();

			return result;
		}

        public async Task<Result<Models.Application>> GetAsyncById(string id)
        {
            var result = await GetAsyncById<Result<Models.Application>>(id);

            return result;
        }

        public async Task<Application>PostAsync(CreateViewModel viewModel)
		{
			var result =await PostAsync<CreateViewModel, Application>(viewModel);

			return result;
		}

        public async Task<Application> PutAsync(CreateViewModel viewModel)
        {
            var result = await PutAsync<CreateViewModel, Application>(viewModel);

            return result;
        }

        public async Task<Result>
         DeleteAsync(string Id)
        {
            var result = await DeleteAsync<Result> (Id);

            return result;
        }
    }
}
