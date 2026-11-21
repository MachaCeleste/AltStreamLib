#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Activity
{
#if NET461 || NET472 || NET481
    public class ActivityEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public ActivityUser User { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        public ActivityEvent(string id, string type, ActivityUser user, string timestamp, string details)
        {
            this.Id = id;
            this.Type = type;
            this.User = user;
            this.Timestamp = timestamp;
            this.Details = details;
        }

        public ActivityEvent() { }
    }
#elif NET9_0_OR_GREATER
    public record ActivityEvent(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("user")] ActivityUser User,
        [property: JsonPropertyName("timestamp")] string Timestamp,
        [property: JsonPropertyName("details")] string Details
    );
#endif
}
