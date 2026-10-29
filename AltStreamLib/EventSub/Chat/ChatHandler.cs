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

        EventType? type = null;
        object? data = null;

        var message = messages[0];
        if (message.Type == MessageType.Message
            || (message.Source is null))
            context = message;
        else
        {
            if (message.Data is not null)
            {
                data = message.Type switch
                {
                    MessageType.Pin => message.Data.Value.Deserialize<ChatPin>(),
                    MessageType.Redemption => message.Data.Value.Deserialize<Redemption>(),
                    MessageType.Highlight => message.Data.Value.Deserialize<Highlight>(),
                    MessageType.Tip => message.Data.Value.Deserialize<KofiEvent>(),
                    MessageType.Subscription => message.Data.Value.Deserialize<KofiEvent>(),
                    MessageType.Shop => message.Data.Value.Deserialize<KofiEvent>(),
                    MessageType.Raid => message.Data.Value.Deserialize<RaidStart>(),
                    MessageType.Shoutout => message.Data.Value.Deserialize<Shoutout>(),
                    _ => null
                };

                if (type is null && message.Type == MessageType.Raid)
                    type = EventType.RaidStarted;
            }
            else
            {
                if (message.Type == MessageType.Raid
                    && message.Text.Contains("is raiding with a party of", StringComparison.Ordinal))
                {
                    string username = message.Text[1..message.Text.IndexOf(' ')];

                    int start = message.Text.IndexOf("party of \"") + 10;
                    int end = message.Text.IndexOf('\"', start);
                    int viewers = int.Parse(message.Text.Substring(start, end - start));

                    type = EventType.RaidReceived;
                    data = new RaidIncoming(username, viewers);
                }
                else if (message.Source is not null && message.Type.Equals(MessageType.System) && message.Text.StartsWith("[RAID_CANCEL]:"))
                {
                    RaidCancel? cancel = JsonSerializer.Deserialize<RaidCancel>(message.Text["[RAID_CANCEL]:".Length..]);
                    if (cancel != null)
                    {
                        data = cancel;
                        type = EventType.RaidCanceled;
                    }
                }
                else if (message.Type == MessageType.Follow
                || message.Type == MessageType.Delete
                || (message.Source is not null && message.Type.Equals(MessageType.System) && message.Text.StartsWith("[SYSTEM_ALERT]:")))
                    data = message.Text.Split(':')[1];
            }

            type ??= message.Type switch
            {
                MessageType.Pin => EventType.Pin,
                MessageType.Unpin => EventType.Unpin,
                MessageType.Redemption => EventType.Redemption,
                MessageType.Highlight => EventType.Highlight,
                MessageType.Tip => EventType.Tip,
                MessageType.Subscription => EventType.Subscription,
                MessageType.Shop => EventType.Shop,
                MessageType.Raid => EventType.RaidStarted,
                MessageType.Shoutout => EventType.Shoutout,
                MessageType.Follow => EventType.Follow,
                MessageType.Delete => EventType.Delete,
                MessageType.System => EventType.System,
                _ => null
            };

            context = new EventMessage(type, data, message);
        }
        return true;
    }
}
