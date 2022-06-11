#nullable disable
using Masya.Bot.Api;

string token = Environment.GetEnvironmentVariable("BOT_TOKEN");

using var client = new RestApiClient(token);

await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);
await client.GetUserAsync(236426208315834369);

var user2 = await client.GetUserAsync(324416295120404480);

Console.WriteLine(user2?.Username);
