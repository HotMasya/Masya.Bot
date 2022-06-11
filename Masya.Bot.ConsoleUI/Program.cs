#nullable disable
using Masya.Bot.Api;

string token = Environment.GetEnvironmentVariable("BOT_TOKEN");

using var client = new RestApiClient(token);

var user = await client.GetUserAsync(236426208315834369);

Console.WriteLine(user?.Username);
