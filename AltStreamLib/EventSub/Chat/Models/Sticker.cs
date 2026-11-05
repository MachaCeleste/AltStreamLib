using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class Sticker
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }

        public Sticker(string url, string name)
        {
            this.Url = url;
            this.Name = name;
        }

        public Sticker() { }
    }
}
