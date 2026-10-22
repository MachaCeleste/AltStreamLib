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

            switch (content)
            {
                case string header when header.StartsWith("[CHAT_PIN]:", StringComparison.Ordinal):
                    {
                        type = EventType.Pin;
                        eventObj = JsonConvert.DeserializeObject<ChatPin>(content.Substring("[CHAT_PIN]:".Length));
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
                        eventObj = JsonConvert.DeserializeObject<Redemption>(content.Substring("[REDEMPTION]:".Length));
                        break;
                    }

                case string header when header.StartsWith("[HIGHLIGHT]:", StringComparison.Ordinal):
                    {
                        type = EventType.Highlight;
                        eventObj = JsonConvert.DeserializeObject<Highlight>(content.Substring("[HIGHLIGHT]:".Length));
                        break;
                    }

                case string header when header.StartsWith("[STREAMER_ONLY_FOLLOW]:", StringComparison.Ordinal):
                    {
                        type = EventType.Follow;
                        eventObj = header.Substring("[STREAMER_ONLY_FOLLOW]:".Length);
                        break;
                    }

                case string header when header.StartsWith("[KOFI_TIP]:", StringComparison.Ordinal):
                    {
                        type = EventType.Tip;
                        eventObj = JsonConvert.DeserializeObject<KofiEvent>(header.Substring("[KOFI_TIP]:".Length));
                        break;
                    }

                case string header when header.StartsWith("[KOFI_SUB]:", StringComparison.Ordinal):
                    {
                        type = EventType.Subscription;
                        eventObj = JsonConvert.DeserializeObject<KofiEvent>(header.Substring("[KOFI_SUB]:".Length));
                        break;
                    }

                case string header when header.StartsWith("[KOFI_SHOP]:", StringComparison.Ordinal):
                    {
                        type = EventType.Shop;
                        eventObj = JsonConvert.DeserializeObject<KofiEvent>(header.Substring("[KOFI_SHOP]:".Length));
                        break;
                    }

                case string header when header.StartsWith("[RAID_START]:", StringComparison.Ordinal):
                    {
                        type = EventType.RaidStart;
                        eventObj = JsonConvert.DeserializeObject<RaidStart>(content.Substring("[RAID_START]:".Length));
                        break;
                    }

                case string header when header.StartsWith("[RAID_CANCEL]:", StringComparison.Ordinal):
                    {
                        type = EventType.RaidCancel;
                        eventObj = JsonConvert.DeserializeObject<RaidCancel>(content.Substring("[RAID_CANCEL]:".Length));
                        break;
                    }

                case string header when header.Contains("is raiding with a party of"):
                    {
                        type = EventType.RaidReceived;
                        string username = content.Substring(1, content.IndexOf(' ') - 1);

                        int start = header.IndexOf("party of \"") + 10;
                        int end = header.IndexOf('\"', start);
                        int viewers = int.Parse(header.Substring(start, end - start));
                        eventObj = new RaidIncoming(username, viewers);
                        break;
                    }

                case string header when header.StartsWith("[SHOUTOUT]:", StringComparison.Ordinal):
                    {
                        type = EventType.Shoutout;
                        eventObj = JsonConvert.DeserializeObject<Shoutout>(content.Substring("[SHOUTOUT]:".Length));
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
                        eventObj = content.Substring("[DELETE]:".Length);
                        break;
                    }

                case string header when header.StartsWith("[SYSTEM_ALERT]:", StringComparison.Ordinal):
                    {
                        type = EventType.SystemMessage;
                        eventObj = header.Substring("[SYSTEM_ALERT]:".Length);
                        break;
                    }
            }

            return new KeyValuePair<EventType, object>(type, eventObj);
        }
    }
}
