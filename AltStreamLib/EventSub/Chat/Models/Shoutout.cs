using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
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
}
