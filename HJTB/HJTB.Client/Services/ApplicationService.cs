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

        public async Task<Result<Application>> GetAsyncById(string id)
        {
            var result = await GetAsyncById<Result<Application>>(id);

            return result;
        }

        public async Task<Result> PostAsync(CreateViewModel viewModel)
		{
			var result =await PostAsync<CreateViewModel, Result>(viewModel);

			return result;
		}

        public async Task<Result> PutAsync(CreateViewModel viewModel)
        {
            var result = await PutAsync<CreateViewModel, Result>(viewModel);

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
