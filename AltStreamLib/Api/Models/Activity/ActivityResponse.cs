#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Activity
{
#if NET461 || NET472 || NET481
    public class ActivityResponse
    {
        [JsonProperty("streamer")]
        public ActivityUser Streamer { get; set; }

        [JsonProperty("stats")]
        public ActivityStats Stats { get; set; }

        [JsonProperty("events")]
        public List<ActivityEvent> Events { get; set; }

        public ActivityResponse(ActivityUser streamer, ActivityStats stats, List<ActivityEvent> events)
        {
            this.Streamer = streamer;
            this.Stats = stats;
            this.Events = events;
        }

        public ActivityResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record ActivityResponse(
        [property: JsonPropertyName("streamer")] ActivityUser Streamer,
        [property: JsonPropertyName("stats")] ActivityStats Stats,
        [property: JsonPropertyName("events")] List<ActivityEvent> Events
    );
#endif
}
