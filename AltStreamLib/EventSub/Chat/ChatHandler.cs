using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using AltStreamLib.EventSub.Chat.Models;
using AltStreamLib.EventSub.Chat.Models.Events;
using AltStreamLib.Logging;

namespace AltStreamLib.EventSub.Chat
{
    internal class ChatHandler
    {
        internal static bool TryDeserializeChatPayload(string payload, out object context)
        {
            context = null;
            List<Message> messages;
            try
            {
                messages = JsonConvert.DeserializeObject<List<Message>>(payload);
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
                context = new EventMessage(ret.Key, ret.Value, message);
            }
            return true;
        }

        private static KeyValuePair<EventType, object> ParseMessageContent(string content)
        {
            var type = EventType.None;
            object eventObj = null;

            if (content.StartsWith("[CHAT_PIN]:", StringComparison.Ordinal))
            {
                type = EventType.Pin;
                eventObj = JsonConvert.DeserializeObject<ChatPin>(content.Substring("[CHAT_PIN]:".Length));
            }
            else if (content.StartsWith("[CHAT_UNPIN]", StringComparison.Ordinal))
            {
                type = EventType.Unpin;
                eventObj = null;
            }
            else if (content.StartsWith("[REDEMPTION]:", StringComparison.Ordinal))
            {
                type = EventType.Redeem;
                eventObj = JsonConvert.DeserializeObject<Redemption>(content.Substring("[REDEMPTION]:".Length));
            }
            else if (content.StartsWith("[HIGHLIGHT]:", StringComparison.Ordinal))
            {
                type = EventType.Highlight;
                eventObj = JsonConvert.DeserializeObject<Highlight>(content.Substring("[HIGHLIGHT]:".Length));
            }
            else if (content.StartsWith("[RAID_START]:", StringComparison.Ordinal))
            {
                type = EventType.RaidStart;
                eventObj = JsonConvert.DeserializeObject<RaidStart>(content.Substring("[RAID_START]:".Length));
            }
            else if (content.StartsWith("[RAID_CANCEL]:", StringComparison.Ordinal))
            {
                type = EventType.RaidCancel;
                eventObj = JsonConvert.DeserializeObject<RaidCancel>(content.Substring("[RAID_CANCEL]:".Length));
            }
            else if (content.Contains("is raiding with a party of"))
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
                eventObj = JsonConvert.DeserializeObject<Shoutout>(content.Substring("[SHOUTOUT]:".Length));
            }
            else if (content.Equals("[CLEAR_CHAT]", StringComparison.Ordinal))
            {
                type = EventType.ClearChat;
                eventObj = null;
            }
            else if (content.StartsWith("[DELETE]:", StringComparison.Ordinal))
            {
                type = EventType.DeleteMessage;
                eventObj = content.Substring("[DELETE]:".Length);
            }

            return new KeyValuePair<EventType, object>(type, eventObj);
        }
    }
}
