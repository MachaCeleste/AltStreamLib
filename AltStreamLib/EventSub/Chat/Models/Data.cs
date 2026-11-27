#if NET461 || NET472 || NET481
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET461 || NET472 || NET481
    public class Data
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public MessageType Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("sentAt")]
        public long SentAt { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("followedBy")]
        public Author FollowedBy { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    
        [JsonProperty("reply")]
        public Reply Reply { get; set; }
    
        [JsonProperty("redemption")]
        public Redemption Redemption { get; set; }
    
        [JsonProperty("raid")]
        public Raid Raid { get; set; }
    
        [JsonProperty("shoutout")]
        public Shoutout Shoutout { get; set; }
    
        [JsonProperty("kofi")]
        public Kofi Kofi { get; set; }

        public Data(string id, MessageType type, string source, long sentAt, Author author, Author followedBy,
            Message message, Reply reply, Redemption redemption, Raid raid, Shoutout shoutout, Kofi kofi)
        {
            this.Id = id;
            this.Type = type;
            this.Source = source;
            this.SentAt = sentAt;
            this.Author = author;
            this.FollowedBy = followedBy;
            this.Message = message;
            this.Reply = reply;
            this.Redemption = redemption;
            this.Raid = raid;
            this.Shoutout = shoutout;
            this.Kofi = kofi;
        }

        public Data() { }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        [EnumMember(Value = "message")] Message,
        [EnumMember(Value = "reply")] Reply,
        [EnumMember(Value = "pin")] Pin,
        [EnumMember(Value = "unpin")] Unpin,
        [EnumMember(Value = "redemption")] Redemption,
        [EnumMember(Value = "highlight")] Highlight,
        [EnumMember(Value = "follow")] Follow,
        [EnumMember(Value = "tip")] Tip,
        [EnumMember(Value = "subscription")] Subscription,
        [EnumMember(Value = "shop")] Shop,
        [EnumMember(Value = "raid_received")] RaidReceived,
        [EnumMember(Value = "raid_started")] RaidStarted,
        [EnumMember(Value = "raid_cancelled")] RaidCancelled,
        [EnumMember(Value = "shoutout")] Shoutout,
        [EnumMember(Value = "clear")] Clear,
        [EnumMember(Value = "delete")] Delete,
        [EnumMember(Value = "system_message")] System
    }
#elif NET9_0_OR_GREATER
    public record Data(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("type")] MessageType Type,
        [property: JsonPropertyName("source")] string Source,
        [property: JsonPropertyName("sentAt")] long SentAt,
        [property: JsonPropertyName("author")] Author? Author,
        [property: JsonPropertyName("followedBy")] Author? FollowedBy,
        [property: JsonPropertyName("message")] Message? Message,
        [property: JsonPropertyName("reply")] Reply? Reply,
        [property: JsonPropertyName("redemption")] Redemption? Redemption,
        [property: JsonPropertyName("raid")] Raid? Raid,
        [property: JsonPropertyName("shoutout")] Shoutout? Shoutout,
        [property: JsonPropertyName("kofi")] Kofi? Kofi
    );

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageType
    {
        [JsonStringEnumMemberName("message")] Message,
        [JsonStringEnumMemberName("reply")] Reply,
        [JsonStringEnumMemberName("pin")] Pin,
        [JsonStringEnumMemberName("unpin")] Unpin,
        [JsonStringEnumMemberName("redemption")] Redemption,
        [JsonStringEnumMemberName("highlight")] Highlight,
        [JsonStringEnumMemberName("follow")] Follow,
        [JsonStringEnumMemberName("tip")] Tip,
        [JsonStringEnumMemberName("subscription")] Subscription,
        [JsonStringEnumMemberName("shop")] Shop,
        [JsonStringEnumMemberName("raid_received")] RaidReceived,
        [JsonStringEnumMemberName("raid_started")] RaidStarted,
        [JsonStringEnumMemberName("raid_cancelled")] RaidCancelled,
        [JsonStringEnumMemberName("shoutout")] Shoutout,
        [JsonStringEnumMemberName("clear")] Clear,
        [JsonStringEnumMemberName("delete")] Delete,
        [JsonStringEnumMemberName("system_message")] System
    }
#endif
}
