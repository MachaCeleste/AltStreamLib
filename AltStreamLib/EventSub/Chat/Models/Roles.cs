using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class Roles
    {
        [JsonProperty("broadcaster")]
        public bool Broadcaster { get; set; }
    
        [JsonProperty("moderator")]
        public bool Moderator { get; set; }
    
        [JsonProperty("channelSubscriber")]
        public bool ChannelSubscriber { get; set; }
    
        [JsonProperty("altstreamSubscriber")]
        public bool AltstreamSubscriber { get; set; }
    
        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        public Roles(bool broadcaster, bool moderator, bool channelSubscriber, bool altstreamSubscriber, bool isBot)
        {
            this.Broadcaster = broadcaster;
            this.Moderator = moderator;
            this.ChannelSubscriber = channelSubscriber;
            this.AltstreamSubscriber = altstreamSubscriber;
            this.IsBot = isBot;
        }

        public Roles() { }
    }
}
