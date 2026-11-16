#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET481
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
#elif NET9_0_OR_GREATER
    public record StreamInfo(
        [property: JsonPropertyName("isLive")] bool IsLive,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("viewers")] int Viewers,
        [property: JsonPropertyName("startedAt")] string StartedAt,
        [property: JsonPropertyName("game")] GameInfo Game,
        [property: JsonPropertyName("tags")] string[] Tags
    );
#endif
}
