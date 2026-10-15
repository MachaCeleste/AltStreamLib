using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class RaidStart
    {
        [JsonProperty("raidId")]
        public int RaidId { get; set; }

        [JsonProperty("sourceChannel")]
        public string SourceChannel { get; set; }

        [JsonProperty("targetUsername")]
        public string TargetUsername { get; set; }

        [JsonProperty("targetDisplayName")]
        public string TargetDisplayName { get; set; }

        [JsonProperty("targetImage")]
        public string TargetImage { get; set; }

        [JsonProperty("viewers")]
        public int Viewers { get; set; }

        [JsonProperty("countdownSeconds")]
        public int CountdownSeconds { get; set; }

        [JsonProperty("startTime")]
        public long StartTime { get; set; }

        public RaidStart(
            int raidId, string sourceChannel, string targetUsername,
            string targetDisplayName, string targetImage, int viewers,
            int countdownSeconds, long startTime)
        {
            this.RaidId = raidId;
            this.SourceChannel = sourceChannel;
            this.TargetUsername = targetUsername;
            this.TargetDisplayName = targetDisplayName;
            this.TargetImage = targetImage;
            this.Viewers = viewers;
            this.CountdownSeconds = countdownSeconds;
            this.StartTime = startTime;
        }

        public RaidStart() { }
    }
}
