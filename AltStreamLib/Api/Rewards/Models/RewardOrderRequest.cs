using Newtonsoft.Json;

namespace AltStreamLib.Api.Rewards.Models
{
    public class RewardOrderRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("orderedIds")]
        public int[] OrderedIds { get; set; }

        public RewardOrderRequest(string username, int[] OrderedIds)
        {
            this.Username = username;
            this.OrderedIds = OrderedIds;
        }

        public RewardOrderRequest() { }
    }
}
