#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET461 || NET472 || NET481
    public class Author
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    
        [JsonProperty("channelName")]
        public string ChannelName { get; set; }
    
        [JsonProperty("pronouns")]
        public string Pronouns { get; set; }
    
        [JsonProperty("image")]
        public string Image { get; set; }
    
        [JsonProperty("color")]
        public string Color { get; set; }
    
        [JsonProperty("roles")]
        public Roles Roles { get; set; }
    
        [JsonProperty("badges")]
        public string[] Badges { get; set; }

        public Author(string id, string displayName, string channelName, string pronouns,
            string image, string color, Roles roles, string[] badges)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.ChannelName = channelName;
            this.Pronouns = pronouns;
            this.Image = image;
            this.Color = color;
            this.Roles = roles;
            this.Badges = badges;
        }

        public Author() { }
    }
#elif NET9_0_OR_GREATER
    public record Author(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("displayName")] string DisplayName,
        [property: JsonPropertyName("channelName")] string ChannelName,
        [property: JsonPropertyName("pronouns")] string? Pronouns,
        [property: JsonPropertyName("image")] string? Image,
        [property: JsonPropertyName("color")] string? Color,
        [property: JsonPropertyName("roles")] Roles Roles,
        [property: JsonPropertyName("badges")] string[] Badges
    );
#endif
}
