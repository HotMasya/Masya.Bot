using Masya.Bot.Enums;
using System.Text.Json.Serialization;

namespace Masya.Bot.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("discriminator")]
        public string Discriminator { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("verified")]
        public bool? Verified { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("flags")]
        public UserFlag? Flags { get; set; }

        [JsonPropertyName("banner")]
        public string? Banner { get; set; }

        [JsonPropertyName("accent_color")]
        public int? AccentColor { get; set; }

        [JsonPropertyName("premium_type")]
        public PremiumType? PremiumType { get; set; }

        [JsonPropertyName("public_flags")]
        public UserFlag? PublicFlags { get; set; }
    }



}
