using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AltStreamLib.EventSub.Chat.Models
{
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

        public Data(string id, MessageType type, string source, long sentAt, Author author,
            Message message, Reply reply, Redemption redemption, Raid raid, Shoutout shoutout, Kofi kofi)
        {
            this.Id = id;
            this.Type = type;
            this.Source = source;
            this.SentAt = sentAt;
            this.Author = author;
            this.Message = message;
            this.Reply = reply;
            this.Redemption = redemption;
            this.Raid = raid;
            this.Shoutout = shoutout;
            this.Kofi = kofi;
        }

        public Data() { }
    }
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
    //[EnumMember(Value = "raid_started")] RaidStarted,
    //[EnumMember(Value = "raid_canceled")] RaidCanceled,
    [EnumMember(Value = "shoutout")] Shoutout,
    [EnumMember(Value = "clear")] Clear,
    [EnumMember(Value = "delete")] Delete,
    [EnumMember(Value = "system")] System
}