using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
    public class StreamInfo
    {
        [JsonProperty("isLive")]
        public bool IsLive { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("viewers")]
        public int Viewers { get; set; }

        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }

        [JsonProperty("game")]
        public GameInfo Game { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        public StreamInfo(bool isLive, string title, int viewers, string startedAt, GameInfo game, string[] tags)
        {
            this.IsLive = isLive;
            this.Title = title;
            this.Viewers = viewers;
            this.StartedAt = startedAt;
            this.Game = game;
            this.Tags = tags;
        }

        public StreamInfo() { }
    }
}
