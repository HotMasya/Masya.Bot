namespace Masya.Bot.Api
{
    internal record ApiRoute(string Name, string RoutePath);

    internal class RestApiRoutes
    {
		private const string ApiVersion = "10";
		private const string Api = $"api/v{ApiVersion}";

        internal static readonly ApiRoute CurrentUser = new("current-user", $"{Api}/users/@me");
        
        internal static ApiRoute SpecificUser(ulong userId) => new("specific-user", $"{Api}/users/{userId}");
    }
}
