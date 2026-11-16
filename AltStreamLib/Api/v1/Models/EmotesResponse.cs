#if NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET481
    public class EmotesResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("emotes")]
        public List<EmoteInfo> Emotes { get; set; }

        public EmotesResponse(string channel, List<EmoteInfo> emotes)
        {
            this.Channel = channel;
            this.Emotes = emotes;
        }

        public EmotesResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record EmotesResponse(
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("emotes")] List<EmoteInfo> Emotes
    );
#endif
}
