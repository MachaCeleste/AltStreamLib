using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
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
}