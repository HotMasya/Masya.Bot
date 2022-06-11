namespace Masya.Bot.Helpers
{
	internal static class DateTimeHelpers
	{
        internal static DateTime UnixTimeStampToDateTime(double timestamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
            return dateTime;
        }
    }
}
