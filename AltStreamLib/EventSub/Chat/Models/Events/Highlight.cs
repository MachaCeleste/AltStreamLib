using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class Highlight
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("rewardName")]
        public string RewardName { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("pointsName")]
        public string PointsName { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public Highlight(string from, string rewardName, int cost, string pointsName, string text)
        {
            this.From = from;
            this.RewardName = rewardName;
            this.Cost = cost;
            this.PointsName = pointsName;
            this.Text = text;
        }

        public Highlight() { }
    }
}