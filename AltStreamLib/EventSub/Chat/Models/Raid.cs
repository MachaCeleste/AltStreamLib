#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET481
    public class Raid
    {
        [JsonProperty("to")]
        public Author To { get; set; }

        [JsonProperty("from")]
        public Author From { get; set; }
    
        [JsonProperty("viewers")]
        public int Viewers { get; set; }

        [JsonProperty("countdownSeconds")]
        public int? CountdownSeconds { get; set; }

        [JsonProperty("startTime")]
        public long? StartTime { get; set; }

        public Raid(Author to, Author from, int viewers, int? countdownSeconds, long? startTime)
        {
            this.To = to;
            this.From = from;
            this.Viewers = viewers;
            this.CountdownSeconds = countdownSeconds;
            this.StartTime = startTime;
        }

        public Raid() { }
    }
#elif NET9_0_OR_GREATER
    public record Raid(
        [property: JsonPropertyName("to")] Author? To,
        [property: JsonPropertyName("from")] Author? From,
        [property: JsonPropertyName("viewers")] int Viewers,
        [property: JsonPropertyName("countdownSeconds")] int? CountdownSeconds,
        [property: JsonPropertyName("startTime")] long? StartTime
    );
#endif
}
