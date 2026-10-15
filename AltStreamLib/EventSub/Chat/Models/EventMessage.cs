using AltStreamLib.EventSub.Chat.Models.Events;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class EventMessage
    {
        public EventType EventType { get; set; }
        public object Event { get; set; }
        public Message Context { get; set; }

        public EventMessage(EventType eventType, object eventData, Message context)
        {
            this.EventType = eventType;
            this.Event = eventData;
            this.Context = context;
        }

        public EventMessage() { }
    }
}
