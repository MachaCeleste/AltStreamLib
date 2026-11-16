#if NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
#endif
using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Chat.Models
{
#if NET481
    public class ModResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("moderators")]
        public List<Moderator> Moderators { get; set; }

        public ModResponse(bool success, List<Moderator> moderators)
        {
            this.Success = success;
            this.Moderators = moderators;
        }
    }
#elif NET9_0_OR_GREATER
    public record ModResponse(
        [property: JsonPropertyName("success")] bool Success,
        [property: JsonPropertyName("moderators")] List<Moderator> Moderators
    );
#endif
}
