#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Live
{
#if NET461 || NET472 || NET481
    public class Game
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        public Game(int id, string name, string slug, string coverUrl, string summary)
        {
            this.Id = id;
            this.Name = name;
            this.Slug = slug;
            this.CoverUrl = coverUrl;
            this.Summary = summary;
        }

        public Game() { }
    }
#elif NET9_0_OR_GREATER
    public record Game(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("slug")] string Slug,
        [property: JsonPropertyName("coverUrl")] string? CoverUrl,
        [property: JsonPropertyName("summary")] string? Summary
    );
#endif
}
