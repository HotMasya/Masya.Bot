namespace System.Net.Http
{
	internal static class HttpResponseExtensions
	{
		internal static T GetHeaderValue<T>(this HttpResponseMessage message, string name) where T: struct
		{
			if(message.Headers.TryGetValues(name, out var values))
			{
				var headerValueStr = values.First();
				return (T)Convert.ChangeType(headerValueStr, typeof(T));
			}

			return default;
		}
	}
}
