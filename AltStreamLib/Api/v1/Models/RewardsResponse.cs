using System.Collections.Generic;
using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
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
}
