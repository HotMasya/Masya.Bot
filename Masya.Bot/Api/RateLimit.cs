#nullable disable
namespace Masya.Bot.Api
{
	internal struct RateLimit
	{
		private readonly int? _limit;
		private readonly int? _remaining;
		private readonly DateTime? _resetDate;
		private readonly double? _resetAfter;

		public int? Limit => _limit;
		public int? Remaining => _remaining;
		public double? ResetAfterSecs => _resetAfter;
		public DateTime? ResetDate => _resetDate;

		public RateLimit(HttpResponseMessage message)
		{
			_limit = message.GetHeaderValue<int>("x-ratelimit-limit");
			_remaining = message.GetHeaderValue<int>("x-ratelimit-remaining");
			_resetAfter = message.GetHeaderValue<double>("x-ratelimit-reset-after");

			double timestamp = message.GetHeaderValue<double>("x-ratelimit-reset");
			_resetDate = DateTimeHelpers.UnixTimeStampToDateTime(timestamp);
		}
	}
}
