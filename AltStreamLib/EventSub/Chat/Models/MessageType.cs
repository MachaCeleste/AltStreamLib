using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageType
{
    [JsonStringEnumMemberName("message")] Message,
    [JsonStringEnumMemberName("pin")] Pin,
    [JsonStringEnumMemberName("unpin")] Unpin,
    [JsonStringEnumMemberName("redemption")] Redemption,
    [JsonStringEnumMemberName("highlight")] Highlight,
    [JsonStringEnumMemberName("follow")] Follow,
    [JsonStringEnumMemberName("tip")] Tip,
    [JsonStringEnumMemberName("subscription")] Subscription,
    [JsonStringEnumMemberName("shop")] Shop,
    [JsonStringEnumMemberName("raid")] Raid,
    //[JsonStringEnumMemberName("raid_received")] RaidReceived,
    //[JsonStringEnumMemberName("raid_started")] RaidStarted,
    //[JsonStringEnumMemberName("raid_canceled")] RaidCanceled,
    [JsonStringEnumMemberName("shoutout")] Shoutout,
    [JsonStringEnumMemberName("clear")] Clear,
    [JsonStringEnumMemberName("delete")] Delete,
    [JsonStringEnumMemberName("system")] System
}