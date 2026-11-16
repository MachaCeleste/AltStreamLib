#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Live.Models
{
#if NET481
    public class UpdateGameRequest
    {

        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("igdbId")]
        public int IgdbId { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("slug")]
        public string Slug { get; set; }
    
        [JsonProperty("coverUrl")]
        public string CoverUrl { get; set; }
    
        [JsonProperty("steamAppId")]
        public string SteamAppId { get; set; }
    
        [JsonProperty("summary")]
        public string Summary { get; set; }
    
        [JsonProperty("streamKey")]
        public string StreamKey { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("usesAiStreamerTools")]
        public bool UsesAiStreamerTools { get; set; }
    
        [JsonProperty("aiStreamerToolsDetails")]
        public string AiStreamerToolsDetails { get; set; }

        public UpdateGameRequest(int id, int igdbId, string name, string slug, string coverUrl, string steamAppId, string summary, string streamKey, string username, bool usesAiStreamerTools, string aiStreamerToolsDetails)
        {
            this.Id = id;
            this.IgdbId = igdbId;
            this.Name = name;
            this.Slug = slug;
            this.CoverUrl = coverUrl;
            this.SteamAppId = steamAppId;
            this.Summary = summary;
            this.StreamKey = streamKey;
            this.Username = username;
            this.UsesAiStreamerTools = usesAiStreamerTools;
            this.AiStreamerToolsDetails = aiStreamerToolsDetails;
        }

        public UpdateGameRequest() { }
    }
#elif NET9_0_OR_GREATER
    public record UpdateGameRequest(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("igdbId")] int IgdbId,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("slug")] string Slug,
        [property: JsonPropertyName("coverUrl")] string? CoverUrl,
        [property: JsonPropertyName("steamAppId")] string? SteamAppId,
        [property: JsonPropertyName("summary")] string? Summary,
        [property: JsonPropertyName("streamKey")] string? StreamKey,
        [property: JsonPropertyName("username")] string? Username,
        [property: JsonPropertyName("usesAiStreamerTools")] bool? UsesAiStreamerTools,
        [property: JsonPropertyName("aiStreamerToolsDetails")] string? AiStreamerToolsDetails
    );
#endif
}
