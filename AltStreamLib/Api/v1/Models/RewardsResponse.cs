#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET461 || NET472 || NET481
    public class RewardsResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("rewards")]
        public List<RewardInfo> Rewards { get; set; }

        public RewardsResponse(string channel, List<RewardInfo> rewards)
        {
            this.Channel = channel;
            this.Rewards = rewards;
        }

        public RewardsResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record RewardsResponse(
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("rewards")] List<RewardInfo> Rewards
    );
#endif
}
