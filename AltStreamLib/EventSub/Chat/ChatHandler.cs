using System.Text.Json;
using System.Text.RegularExpressions;
using AltStreamLib.EventSub.Chat.Models;
using AltStreamLib.EventSub.Chat.Models.Events;

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

        if (content.StartsWith("[CHAT_PIN]:", StringComparison.Ordinal))
        {
            type = EventType.Pin;
            eventObj = JsonSerializer.Deserialize<ChatPin>(content["[CHAT_PIN]:".Length..]);
        }
        else if (content.StartsWith("[CHAT_UNPIN]", StringComparison.Ordinal))
        {
            type = EventType.Unpin;
            eventObj = null;
        }
        else if (content.StartsWith("[REDEMPTION]:", StringComparison.Ordinal))
        {
            type = EventType.Redeem;
            eventObj = JsonSerializer.Deserialize<Redemption>(content["[REDEMPTION]:".Length..]);
        }
        else if (content.StartsWith("[HIGHLIGHT]:", StringComparison.Ordinal))
        {
            type = EventType.Highlight;
            eventObj = JsonSerializer.Deserialize<Highlight>(content["[HIGHLIGHT]:".Length..]);
        }
        else if (content.StartsWith("[RAID_START]:", StringComparison.Ordinal))
        {
            type = EventType.RaidStart;
            eventObj = JsonSerializer.Deserialize<RaidStart>(content["[RAID_START]:".Length..]);
        }
        else if (content.StartsWith("[RAID_CANCEL]:", StringComparison.Ordinal))
        {
            type = EventType.RaidCancel;
            eventObj = JsonSerializer.Deserialize<RaidCancel>(content["[RAID_CANCEL]:".Length..]);
        }
        else if (content.Contains("is raiding with a party of", StringComparison.Ordinal))
        {
            type = EventType.RaidReceived;
            string username = content.Substring(1, content.IndexOf(' ') - 1);

            int start = content.IndexOf("party of \"") + 10;
            int end = content.IndexOf('\"', start);
            int viewers = int.Parse(content.Substring(start, end - start));
            eventObj = new RaidIncoming(username, viewers);
        }
        else if (content.StartsWith("[SHOUTOUT]:", StringComparison.Ordinal))
        {
            type = EventType.Shoutout;
            eventObj = JsonSerializer.Deserialize<Shoutout>(content["[SHOUTOUT]:".Length..]);
        }
        else if (content.Equals("[CLEAR_CHAT]", StringComparison.Ordinal))
        {
            type = EventType.ClearChat;
            eventObj = null;
        }
        else if (content.StartsWith("[DELETE]:", StringComparison.Ordinal))
        {
            type = EventType.DeleteMessage;
            eventObj = content["[DELETE]:".Length..];
        }

        return (type, eventObj);
    }
}
