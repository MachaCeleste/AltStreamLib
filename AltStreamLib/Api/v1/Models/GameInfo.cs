using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
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
}
