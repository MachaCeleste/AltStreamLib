using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Data(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("type")] MessageType Type,
    [property: JsonPropertyName("source")] string Source,
    [property: JsonPropertyName("sentAt")] long SentAt,
    [property: JsonPropertyName("author")] Author? Author,
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
    //[JsonStringEnumMemberName("raid_started")] RaidStarted,
    //[JsonStringEnumMemberName("raid_canceled")] RaidCanceled,
    [JsonStringEnumMemberName("shoutout")] Shoutout,
    [JsonStringEnumMemberName("clear")] Clear,
    [JsonStringEnumMemberName("delete")] Delete,
    [JsonStringEnumMemberName("system")] System
}