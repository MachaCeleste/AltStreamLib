#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Shoutout
{
#if NET461 || NET472 || NET481
    public class ShoutoutRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
    
        [JsonProperty("target")]
        public string Target { get; set; }

        public ShoutoutRequest(string channel, string target)
        {
            this.Channel = channel;
            this.Target = target;
        }

        public ShoutoutRequest() { }
    }
#elif NET9_0_OR_GREATER
    public record ShoutoutRequest(
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("target")] string Target
    );
#endif
}
