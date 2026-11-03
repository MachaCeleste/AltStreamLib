using Newtonsoft.Json;

namespace AltStreamLib.Api.Live.Models
{
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
}
