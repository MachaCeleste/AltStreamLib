using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class Redemption
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("rewardName")]
        public string RewardName { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("pointsName")]
        public string PointsName { get; set; }

        [JsonProperty("userInput")]
        public string UserInput { get; set; }

        public Redemption(string from, string rewardName, int cost, string pointsName, string userInput)
        {
            this.From = from;
            this.RewardName = rewardName;
            this.Cost = cost;
            this.PointsName = pointsName;
            this.UserInput = userInput;
        }

        public Redemption() { }
    }
}
