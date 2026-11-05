using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
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
}
