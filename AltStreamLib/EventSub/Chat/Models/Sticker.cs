#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET461 || NET472 || NET481
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
#elif NET9_0_OR_GREATER
    public record Sticker(
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("name")] string Name
    );
#endif
}
