#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Admin
{
#if NET461 || NET472 || NET481
    public class ChatUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("joinedAt")]
        public string JoinedAt { get; set; }

        public ChatUser(string id, string name, string type, string image, string country, string countryCode, string flag, string joinedAt)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Image = image;
            this.Country = country;
            this.CountryCode = countryCode;
            this.Flag = flag;
            this.JoinedAt = joinedAt;
        }

        public ChatUser() { }
    }
#elif NET9_0_OR_GREATER
    public record ChatUser(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("image")] string Image,
        [property: JsonPropertyName("country")] string Country,
        [property: JsonPropertyName("countryCode")] string CountryCode,
        [property: JsonPropertyName("flag")] string Flag,
        [property: JsonPropertyName("joinedAt")] string JoinedAt
    );
#endif
}
