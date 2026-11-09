using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
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
}
