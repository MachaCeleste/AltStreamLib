using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("text")]
        public string Text { get; set; }
    
        [JsonProperty("sticker")]
        public Sticker Sticker { get; set; }

        public Message(string id, string text, Sticker sticker)
        {
            this.Id = id;
            this.Text = text;
            this.Sticker = sticker;
        }

        public Message() { }
    }
}
