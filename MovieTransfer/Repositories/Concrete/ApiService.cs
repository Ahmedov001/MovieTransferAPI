using Microsoft.Extensions.Hosting;
using MovieTransfer.Entities;
using MovieTransfer.Repositories.Abstract;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieTransfer.Repositories.Concrete
{
	public class ApiService : IApiService
	{
		private readonly HttpClient _httpClient;

		public ApiService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Stream> GetDataAsync(string url)
		{
			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();
			var jsonString =  await response.Content.ReadAsStreamAsync();
			Console.WriteLine(jsonString.GetType());
			return jsonString;
		}
	}
}
