#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET461 || NET472 || NET481
    public class GameInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }

        public GameInfo(int id, string name, string slug, string coverUrl)
        {
            this.Id = id;
            this.Name = name;
            this.Slug = slug;
            this.CoverUrl = coverUrl;
        }

        public GameInfo() { }
    }
#elif NET9_0_OR_GREATER
    public record GameInfo(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("slug")] string Slug,
        [property: JsonPropertyName("coverUrl")] string CoverUrl
    );
#endif
}
