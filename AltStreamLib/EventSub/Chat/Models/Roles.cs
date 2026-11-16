#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET481
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

        [JsonProperty("follower")]
        public bool Follower { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        public Roles(bool broadcaster, bool moderator, bool channelSubscriber, bool altstreamSubscriber, bool follower, bool isBot)
        {
            this.Broadcaster = broadcaster;
            this.Moderator = moderator;
            this.ChannelSubscriber = channelSubscriber;
            this.AltstreamSubscriber = altstreamSubscriber;
            this.Follower = follower;
            this.IsBot = isBot;
        }

        public Roles() { }
    }
#elif NET9_0_OR_GREATER
    public record Roles(
        [property: JsonPropertyName("broadcaster")] bool Broadcaster,
        [property: JsonPropertyName("moderator")] bool Moderator,
        [property: JsonPropertyName("channelSubscriber")] bool ChannelSubscriber,
        [property: JsonPropertyName("altstreamSubscriber")] bool AltstreamSubscriber,
        [property: JsonPropertyName("follower")] bool Follower,
        [property: JsonPropertyName("isBot")] bool IsBot
    );
#endif
}
