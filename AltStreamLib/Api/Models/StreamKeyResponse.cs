using Newtonsoft.Json;

namespace AltStreamLib.Api.Models
{
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
}
