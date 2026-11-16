#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET481
    public class PanelInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        public PanelInfo(int id, string slug, string title, string content, int displayOrder)
        {
            this.Id = id;
            this.Slug = slug;
            this.Title = title;
            this.Content = content;
            this.DisplayOrder = displayOrder;
        }

        public PanelInfo() { }
    }
#elif NET9_0_OR_GREATER
    public record PanelInfo(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("slug")] string Slug,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("content")] string Content,
        [property: JsonPropertyName("displayOrder")] int DisplayOrder
    );
#endif
}
