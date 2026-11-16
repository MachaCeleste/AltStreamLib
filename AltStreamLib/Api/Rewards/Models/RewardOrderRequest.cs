#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Rewards.Models
{
#if NET481
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
#elif NET9_0_OR_GREATER
    internal record RewardOrderRequest(
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("orderedIds")] int[] OrderedIds
    );
#endif
}
