#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

using AltStreamLib.Api.Models.v1;
using AltStreamLib.EventSub.Chat.Models;

namespace AltStreamLib.Api.Models.v2
{
#if NET461 || NET472 || NET481
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }
    
        [JsonProperty("channelName")]
        public string ChannelName { get; set; }
    
        [JsonProperty("pronouns")]
        public string Pronouns { get; set; }
    
        [JsonProperty("image")]
        public string Image { get; set; }
    
        [JsonProperty("color")]
        public string Color { get; set; }
    
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
    
        [JsonProperty("roles")]
        public Roles Roles { get; set; }

        [JsonProperty("currentGame")]
        public GameInfo CurrentGame { get; set; }

        public User(string id, string displayName, string channelName, string pronouns, string image, string color, string createdAt, Roles roles, GameInfo currentGame)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.ChannelName = channelName;
            this.Pronouns = pronouns;
            this.Image = image;
            this.Color = color;
            this.CreatedAt = createdAt;
            this.Roles = roles;
            this.CurrentGame = currentGame;
        }

        public User() { }
    }
#elif NET9_0_OR_GREATER
    public record User(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("DisplayName")] string DisplayName,
        [property: JsonPropertyName("channelName")] string ChannelName,
        [property: JsonPropertyName("pronouns")] string Pronouns,
        [property: JsonPropertyName("image")] string Image,
        [property: JsonPropertyName("color")] string Color,
        [property: JsonPropertyName("createdAt")] string CreatedAt,
        [property: JsonPropertyName("roles")] Roles Roles,
        [property: JsonPropertyName("currentGame")] GameInfo CurrentGame
    );
#endif
}
