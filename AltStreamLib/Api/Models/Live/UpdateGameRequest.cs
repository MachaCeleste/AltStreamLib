#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Live
{
#if NET461 || NET472 || NET481
    public class UpdateGameRequest
    {
        [JsonProperty("igdbId")]
        public int IgdbId { get; set; }

        [JsonProperty("adultDisclosed")]
        public bool AdultDisclosed { get; set; }

        [JsonProperty("aiDisclosed")]
        public bool AiDisclosed { get; set; }

        [JsonProperty("aiDetails")]
        public string AiDetails { get; set; }

        [JsonProperty("usesAiStreamerTools")]
        public bool UsesAiStreamerTools { get; set; }
    
        [JsonProperty("aiStreamerToolsDetails")]
        public string AiStreamerToolsDetails { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("streamKey")]
        public string StreamKey { get; set; }

        public UpdateGameRequest(int igdbId, bool adultDisclosed, bool aiDisclosed, string aiDetails,
            bool usesAiStreamerTools, string aiStreamerToolsDetails, string username, string streamKey)
        {
            this.IgdbId = igdbId;
            this.AdultDisclosed = adultDisclosed;
            this.AiDisclosed = aiDisclosed;
            this.AiDetails = aiDetails;
            this.UsesAiStreamerTools = usesAiStreamerTools;
            this.AiStreamerToolsDetails = aiStreamerToolsDetails;
            this.Username = username;
            this.StreamKey = streamKey;
        }

        public UpdateGameRequest() { }
    }
#elif NET9_0_OR_GREATER
    public record UpdateGameRequest(
        [property: JsonPropertyName("igdbId")] int IgdbId,
        [property: JsonPropertyName("adultDisclosed")] bool AdultDisclosed,
        [property: JsonPropertyName("aiDisclosed")] bool AiDisclosed,
        [property: JsonPropertyName("aiDetails")] string? AiDetails,
        [property: JsonPropertyName("usesAiStreamerTools")] bool UsesAiStreamerTools,
        [property: JsonPropertyName("aiStreamerToolsDetails")] string? AiStreamerToolsDetails,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("streamKey")] string StreamKey
    );
#endif
}
