using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class Author
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("display")]
        public string Display { get; set; }
    
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

        public Author(string id, string display, string channelName, string pronouns,
            string image, string color, Roles roles, string[] badges)
        {
            this.Id = id;
            this.Display = display;
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
