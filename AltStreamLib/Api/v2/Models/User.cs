using Newtonsoft.Json;
using AltStreamLib.EventSub.Chat.Models;

namespace AltStreamLib.Api.v2.Models
{
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

        public User(string id, string displayName, string channelName, string pronouns, string image, string color, string createdAt, Roles roles)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.ChannelName = channelName;
            this.Pronouns = pronouns;
            this.Image = image;
            this.Color = color;
            this.CreatedAt = createdAt;
            this.Roles = roles;
        }

        public User() { }
    }
}
