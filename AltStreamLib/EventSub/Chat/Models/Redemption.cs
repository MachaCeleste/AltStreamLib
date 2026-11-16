#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET481
    public class Redemption
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("rewardId")]
        public string RewardId { get; set; }
    
        [JsonProperty("from")]
        public Author From { get; set; }
    
        [JsonProperty("rewardName")]
        public string RewardName { get; set; }
    
        [JsonProperty("cost")]
        public int Cost { get; set; }
    
        [JsonProperty("pointsName")]
        public string PointsName { get; set; }
    
        [JsonProperty("userInput")]
        public string UserInput { get; set; }

        public Redemption(string id, string rewardId, Author from, string rewardName, int cost, string pointsName, string userInput)
        {
            this.Id = id;
            this.RewardId = rewardId;
            this.From = from;
            this.RewardName = rewardName;
            this.Cost = cost;
            this.PointsName = pointsName;
            this.UserInput = userInput;
        }

        public Redemption() { }
    }
#elif NET9_0_OR_GREATER
    public record Redemption(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("rewardId")] string RewardId,
        [property: JsonPropertyName("from")] Author From,
        [property: JsonPropertyName("rewardName")] string RewardName,
        [property: JsonPropertyName("cost")] int Cost,
        [property: JsonPropertyName("pointsName")] string PointsName,
        [property: JsonPropertyName("userInput")] string? UserInput
    );
#endif
}
