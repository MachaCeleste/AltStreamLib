#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET481
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
#elif NET9_0_OR_GREATER
    public record Message(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("text")] string Text,
        [property: JsonPropertyName("sticker")] Sticker? Sticker
    );
#endif
}
