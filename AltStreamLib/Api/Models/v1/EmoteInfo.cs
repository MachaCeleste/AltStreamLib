#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.v1
{
#if NET461 || NET472 || NET481
    public class EmoteInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        public EmoteInfo(int id, string name, string url, int displayOrder)
        {
            this.Id = id;
            this.Name = name;
            this.Url = url;
            this.DisplayOrder = displayOrder;
        }

        public EmoteInfo() { }
    }
#elif NET9_0_OR_GREATER
    public record EmoteInfo(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("displayOrder")] int DisplayOrder
    );
#endif
}
