#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET481
    public class Shoutout
    {
        [JsonProperty("target")]
        public Author Target { get; set; }

        public Shoutout(
            Author target)
        {
            this.Target = target;
        }

        public Shoutout() { }
    }
#elif NET9_0_OR_GREATER
    public record Shoutout(
        [property: JsonPropertyName("target")] Author Target
    );
#endif
}
