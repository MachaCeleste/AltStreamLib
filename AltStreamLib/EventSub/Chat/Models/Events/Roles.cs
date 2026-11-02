using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class Roles
    {
        [JsonProperty("broadcaster")]
        public bool Broadcaster { get; set; }
    
        [JsonProperty("moderator")]
        public bool Moderator { get; set; }

        [JsonProperty("subscriber")]
        public bool Subscriber { get; set; }

        [JsonProperty("supporter")]
        public bool Supporter { get; set; }

        public Roles(bool broadcaster, bool moderator, bool subscriber, bool supporter)
        {
            this.Broadcaster = broadcaster;
            this.Moderator = moderator;
            this.Subscriber = subscriber;
            this.Supporter = supporter;
        }

        public Roles() { }
    }
}
