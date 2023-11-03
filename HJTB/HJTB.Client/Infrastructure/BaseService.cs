using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
	public abstract class BaseService 
	{
		public BaseService(HttpClient http) : base()
		{
			JsonOptions =
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true,
				};

			Http = http;
			//Client.DefaultRequestHeaders

			BaseUrl = "http://localhost:5086";
			RequestUri = $"{ BaseUrl }/{ GetApiUrl() }";
		}

		protected abstract string GetApiUrl();

		protected string BaseUrl { get; set; }

		protected string RequestUri { get; set; }

		protected HttpClient Http { get; set; }

		protected JsonSerializerOptions JsonOptions { get; set; }

		protected virtual async Task<O> GetAsync<O>()
		{
			HttpResponseMessage response = null;

			try
			{
				response =await Http.GetAsync(requestUri: RequestUri);

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						O result =
							await response.Content.ReadFromJsonAsync<O>();

						return result;
					}
					// When content type is not valid
					catch (NotSupportedException)
					{
						System.Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (JsonException)
					{
						System.Console.WriteLine("Invalid JSON.");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
			}

			return default;
		}

        protected virtual async Task<O> GetAsyncById<O>(string id)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await Http.GetAsync(requestUri: RequestUri + $"/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }

        protected virtual async Task<O> PostAsync<I, O>(I viewModel)
		{
			HttpResponseMessage response = null;

			try
			{
				response =await Http.PostAsJsonAsync(requestUri: RequestUri, value: viewModel);

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
					
						O result =await response.Content.ReadFromJsonAsync<O>();

						return result;
						
					}
					// When content type is not valid
					catch (System.NotSupportedException)
					{
						System.Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (System.Text.Json.JsonException)
					{
						System.Console.WriteLine("Invalid JSON.");
					}
				}
			}
			catch (System.Net.Http.HttpRequestException ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
				//response = null;
			}

			return default;
		}

		protected virtual async Task<O> PutAsync<I, O>(I viewModel)
		{
			System.Net.Http.HttpResponseMessage response = null;

			try
			{
				response =await Http.PutAsJsonAsync(requestUri: RequestUri, value: viewModel);

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						O result =await response.Content.ReadFromJsonAsync<O>();

						return result;
					}
					// When content type is not valid
					catch (NotSupportedException)
					{
						Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (JsonException)
					{
						Console.WriteLine("Invalid JSON.");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
			}

			return default;
		}

        protected virtual async Task<O>DeleteAsync<O>(string Id)
        {
            HttpResponseMessage response = null;

            try
            {
                response =await Http.DeleteAsync(requestUri: RequestUri + $"/{Id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }
                    // When content type is not valid
                    catch (NotSupportedException)
                    {
                        Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (JsonException)
                    {
                       Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }
    }
}
