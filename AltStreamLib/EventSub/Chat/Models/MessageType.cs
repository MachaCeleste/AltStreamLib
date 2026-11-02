using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AltStreamLib.EventSub.Chat.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum MessageType
{
    [EnumMember(Value = "message")] Message,
    [EnumMember(Value = "pin")] Pin,
    [EnumMember(Value = "unpin")] Unpin,
    [EnumMember(Value = "redemption")] Redemption,
    [EnumMember(Value = "highlight")] Highlight,
    [EnumMember(Value = "follow")] Follow,
    [EnumMember(Value = "tip")] Tip,
    [EnumMember(Value = "subscription")] Subscription,
    [EnumMember(Value = "shop")] Shop,
    [EnumMember(Value = "raid")] Raid,
    //[EnumMember(Value = "raid_received")] RaidReceived,
    //[EnumMember(Value = "raid_started")] RaidStarted,
    //[EnumMember(Value = "raid_canceled")] RaidCanceled,
    [EnumMember(Value = "shoutout")] Shoutout,
    [EnumMember(Value = "clear")] Clear,
    [EnumMember(Value = "delete")] Delete,
    [EnumMember(Value = "system")] System
}