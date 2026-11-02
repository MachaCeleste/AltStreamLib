using AltStreamLib.EventSub.Chat.Models.Events;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class EventMessage
    {
        public EventType? Type { get; set; }
        public object Event { get; set; }
        public Message Context { get; set; }

        public EventMessage(EventType? type, object eventData, Message context)
        {
            this.Type = type;
            this.Event = eventData;
            this.Context = context;
        }

        public EventMessage() { }
    }
}
