#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Activity
{
#if NET461 || NET472 || NET481
    public class ActivityStats
    {
        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("subscribers")]
        public int Subscribers { get; set; }

        public ActivityStats(int followers, int subscribers)
        {
            this.Followers = followers;
            this.Subscribers = subscribers;
        }

        public ActivityStats() { }
    }
#elif NET9_0_OR_GREATER
    public record ActivityStats(
        [property: JsonPropertyName("followers")] int Followers,
        [property: JsonPropertyName("subscribers")] int Subscribers
    );
#endif
}
