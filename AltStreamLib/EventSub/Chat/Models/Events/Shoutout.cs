using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class Shoutout
    {
        [JsonProperty("targetUsername")]
        public string TargetUsername { get; set; }

        [JsonProperty("targetDisplayName")]
        public string TargetDisplayName { get; set; }

        [JsonProperty("targetAvatar")]
        public string TargetAvatar { get; set; }

        [JsonProperty("targetBio")]
        public string TargetBio { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("gameCover")]
        public string GameCover { get; set; }

        [JsonProperty("shoutedBy")]
        public string ShoutedBy { get; set; }

        public Shoutout(
            string targetUsername, string targetDisplayName, string targetAvatar,
            string targetBio, string gameName, string gameCover, string shoutedBy)
        {
            this.TargetUsername = targetUsername;
            this.TargetDisplayName = targetDisplayName;
            this.TargetAvatar = targetAvatar;
            this.TargetBio = targetBio;
            this.GameName = gameName;
            this.GameCover = gameCover;
            this.ShoutedBy = shoutedBy;
        }

        public Shoutout() { }
    }
}
