#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models
{
#if NET481
    public class StreamKeyResponse
    {
        [JsonProperty("streamKey")]
        public string StreamKey { get; set; }
    
        [JsonProperty("hasStreamerKey")]
        public bool HasStreamKey { get; set; }

        public StreamKeyResponse(string streamKey, bool hasStreamKey)
        {
            this.StreamKey = streamKey;
            this.HasStreamKey = hasStreamKey;
        }

        public StreamKeyResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record StreamKeyResponse(
        [property: JsonPropertyName("streamKey")] string StreamKey,
        [property: JsonPropertyName("hasStreamerKey")] bool HasStreamKey
    );
#endif
}
