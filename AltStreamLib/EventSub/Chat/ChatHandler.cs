using System.Text.Json;
using AltStreamLib.EventSub.Chat.Models;
using AltStreamLib.EventSub.Chat.Models.Events;
using AltStreamLib.Logging;

namespace AltStreamLib.EventSub.Chat;

internal class ChatHandler
{
    internal static bool TryDeserializeChatPayload(string payload, out object? context)
    {
        context = null;
        List<Message>? messages;
        try
        {
            messages = JsonSerializer.Deserialize<List<Message>>(payload);
        }
        catch (JsonException ex)
        {
            Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
            return false;
        }

        if (messages == null || messages.Count == 0)
            return false;

        var message = messages[0];
        if (message.Source.Equals("local", StringComparison.Ordinal))
            context = message;
        else
        {
            var ret = ParseMessageContent(message.Text);
            context = new EventMessage(ret.type, ret.eventObj, message);
        }
        return true;
    }

    private static (EventType type, object? eventObj) ParseMessageContent(string content)
    {
        var type = EventType.None;
        object? eventObj = null;

        switch (content)
        {
            case string header when header.StartsWith("[CHAT_PIN]:", StringComparison.Ordinal):
                {
                    type = EventType.Pin;
                    eventObj = JsonSerializer.Deserialize<ChatPin>(header["[CHAT_PIN]:".Length..]);
                    break;
                }

            case string header when header.StartsWith("[CHAT_UNPIN]", StringComparison.Ordinal):
                {
                    type = EventType.Unpin;
                    eventObj = null;
                    break;
                }

            case string header when header.StartsWith("[REDEMPTION]:", StringComparison.Ordinal):
                {
                    type = EventType.Redeem;
                    eventObj = JsonSerializer.Deserialize<Redemption>(header["[REDEMPTION]:".Length..]);
                    break;
                }

            case string header when header.StartsWith("[HIGHLIGHT]:", StringComparison.Ordinal):
                {
                    type = EventType.Highlight;
                    eventObj = JsonSerializer.Deserialize<Highlight>(header["[HIGHLIGHT]:".Length..]);
                    break;
                }

            case string header when header.StartsWith("[STREAMER_ONLY_FOLLOW]:", StringComparison.Ordinal):
                {
                    type = EventType.Follow;
                    eventObj = header["[STREAMER_ONLY_FOLLOW]:".Length..];
                    break;
                }

            case string header when header.StartsWith("[KOFI_TIP]:", StringComparison.Ordinal):
                {
                    type = EventType.Tip;
                    eventObj = JsonSerializer.Deserialize<KofiEvent>(header["[KOFI_TIP]:".Length..]);
                    break;
                }

            case string header when header.StartsWith("[KOFI_SUB]:", StringComparison.Ordinal):
                {
                    type = EventType.Subscription;
                    eventObj = JsonSerializer.Deserialize<KofiEvent>(header["[KOFI_SUB]:".Length..]);
                    break;
                }

            case string header when header.StartsWith("[KOFI_SHOP]:", StringComparison.Ordinal):
                {
                    type = EventType.Shop;
                    eventObj = JsonSerializer.Deserialize<KofiEvent>(header["[KOFI_SHOP]:".Length..]);
                    break;
                }

            case string header when header.StartsWith("[RAID_START]:", StringComparison.Ordinal):
                {
                    type = EventType.RaidStart;
                    eventObj = JsonSerializer.Deserialize<RaidStart>(header["[RAID_START]:".Length..]);
                    break;
                }

            case string header when header.StartsWith("[RAID_CANCEL]:", StringComparison.Ordinal):
                {
                    type = EventType.RaidCancel;
                    eventObj = JsonSerializer.Deserialize<RaidCancel>(header["[RAID_CANCEL]:".Length..]);
                    break;
                }

            case string header when header.Contains("is raiding with a party of", StringComparison.Ordinal):
                {
                    type = EventType.RaidReceived;
                    string username = header[1..header.IndexOf(' ')];

                    int start = header.IndexOf("party of \"") + 10;
                    int end = header.IndexOf('\"', start);
                    int viewers = int.Parse(header.Substring(start, end - start));
                    eventObj = new RaidIncoming(username, viewers);
                    break;
                }

            case string header when header.StartsWith("[SHOUTOUT]:", StringComparison.Ordinal):
                {
                    type = EventType.Shoutout;
                    eventObj = JsonSerializer.Deserialize<Shoutout>(header["[SHOUTOUT]:".Length..]);
                    break;
                }

            case string header when header.Equals("[CLEAR_CHAT]", StringComparison.Ordinal):
                {
                    type = EventType.ClearChat;
                    eventObj = null;
                    break;
                }

            case string header when header.StartsWith("[DELETE]:", StringComparison.Ordinal):
                {
                    type = EventType.DeleteMessage;
                    eventObj = header["[DELETE]:".Length..];
                    break;
                }

            case string header when header.StartsWith("[SYSTEM_ALERT]:", StringComparison.Ordinal):
                {
                    type = EventType.SystemMessage;
                    eventObj = header["[SYSTEM_ALERT]:".Length..];
                    break;
                }
        }

        return (type, eventObj);
    }
}
