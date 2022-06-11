using Masya.Bot.Models;
using System.Text.Json;

namespace Masya.Bot.Api
{
    public sealed class RestApiClient : IDisposable
    {
        private readonly DiscordHttpClient _http;
        private readonly string _token;

		public const string BaseUrl = $"https://discord.com";

		public RestApiClient(string token, HttpClient? httpClient = null)
        {
            _token = token;
			if(httpClient != null)
			{
				_http = new DiscordHttpClient(httpClient);
				return;
			}

			var http = new HttpClient()
			{
				BaseAddress = new Uri(BaseUrl),
			};

			http.DefaultRequestHeaders.Add("Authorization", $"Bot {_token}");
				
			_http = new DiscordHttpClient(http);
        }

		public async Task<User?> GetMeAsync()
		{
			try
			{
				var response = await _http.GetAsync(RestApiRoutes.CurrentUser);

				using Stream content = await response.Content.ReadAsStreamAsync();
				return await JsonSerializer.DeserializeAsync<User>(content);
			} 
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}

		public async Task<User?> GetUserAsync(ulong userId)
		{
			try
			{
				var response = await _http.GetAsync(RestApiRoutes.SpecificUser(userId));
				using Stream content = await response.Content.ReadAsStreamAsync();
				return await JsonSerializer.DeserializeAsync<User>(content);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}

		public void Dispose()
		{
			_http.Dispose();
		}
	}
}
