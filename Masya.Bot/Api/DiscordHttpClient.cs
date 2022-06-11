namespace Masya.Bot.Api
{
	internal class DiscordHttpClient : IDisposable
	{
		private readonly HttpClient _http;
		private readonly Dictionary<string, RateLimit> _limits;

		public HttpClient Http => _http;

		public DiscordHttpClient(HttpClient? http = null)
		{
			_http = http ?? new HttpClient();
			_limits = new Dictionary<string, RateLimit>();
		}
			
		public async Task<HttpResponseMessage> GetAsync(ApiRoute route, CancellationToken cancellationToken = default)
		{
			await ValidateRateLimitAsync(route);

			var response = await _http.GetAsync(route.RoutePath, cancellationToken);
			SetRequestRateLimit(route, response);
			return response;
		}

		public async Task<HttpResponseMessage> PostAsync(
			ApiRoute route, 
			HttpContent? content, 
			CancellationToken cancellationToken = default)
		{
			await ValidateRateLimitAsync(route);

			var response = await _http.PostAsync(route.RoutePath, content, cancellationToken);
			SetRequestRateLimit(route, response);
			return response;
		}

		public async Task<HttpResponseMessage> PatchAsync(
			ApiRoute route,
			HttpContent? content,
			CancellationToken cancellationToken = default)
		{
			await ValidateRateLimitAsync(route);

			var response = await _http.PatchAsync(route.RoutePath, content, cancellationToken);
			SetRequestRateLimit(route, response);
			return response;
		}

		public async Task<HttpResponseMessage> PutAsync(
			ApiRoute route,
			HttpContent? content,
			CancellationToken cancellationToken = default)
		{
			await ValidateRateLimitAsync(route);

			var response = await _http.PutAsync(route.RoutePath, content, cancellationToken);
			SetRequestRateLimit(route, response);
			return response;
		}

		public async Task<HttpResponseMessage> DeleteAsync(
		ApiRoute route,
		CancellationToken cancellationToken = default)
		{
			await ValidateRateLimitAsync(route, cancellationToken);

			var response = await _http.DeleteAsync(route.RoutePath, cancellationToken);
			SetRequestRateLimit(route, response);
			return response;
		}

		private async Task ValidateRateLimitAsync(ApiRoute route, CancellationToken cancellationToken = default)
		{
			if (_limits.TryGetValue(route.Name, out var limit))
			{
				if (limit.Remaining == 0 && limit.ResetAfterSecs.HasValue)
				{
					int msToWait = (int)Math.Ceiling(limit.ResetAfterSecs.Value) * 1000;
					await Task.Delay(msToWait, cancellationToken);
				}
			}
		}

		private void SetRequestRateLimit(ApiRoute route, HttpResponseMessage? message)
		{
			var rateLimit = new RateLimit(message);

			if(rateLimit.Limit > 0)
			{
				if(_limits.ContainsKey(route.Name))
				{
					_limits[route.Name] = rateLimit;
					return;
				}
				
				_limits.Add(route.Name, rateLimit);
			}
		}

		public void Dispose()
		{
			_http?.Dispose();
		}
	}
}
