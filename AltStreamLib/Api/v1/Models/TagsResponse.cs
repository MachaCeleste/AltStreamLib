#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET481
    public class TagsResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        public TagsResponse(string channel, string[] tags)
        {
            this.Channel = channel;
            this.Tags = tags;
        }

        public TagsResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record TagsResponse(
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("tags")] string[] Tags
    );
#endif
}
