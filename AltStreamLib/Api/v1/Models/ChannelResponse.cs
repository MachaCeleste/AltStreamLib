#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET481
    public class ChannelResponse
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("stream")]
        public StreamInfo Stream { get; set; }

        public ChannelResponse(string username, string displayName, string avatarUrl, string bio, string createdAt, StreamInfo stream)
        {
            this.Username = username;
            this.DisplayName = displayName;
            this.AvatarUrl = avatarUrl;
            this.Bio = bio;
            this.CreatedAt = createdAt;
            this.Stream = stream;
        }

        public ChannelResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record ChannelResponse(
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("displayName")] string DisplayName,
        [property: JsonPropertyName("avatarUrl")] string AvatarUrl,
        [property: JsonPropertyName("bio")] string Bio,
        [property: JsonPropertyName("createdAt")] string CreatedAt,
        [property: JsonPropertyName("stream")] StreamInfo Stream
    );
#endif
}
