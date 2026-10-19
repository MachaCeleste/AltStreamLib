using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
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
}
