using AltStreamLib.EventSub.Chat.Models.Events;

namespace AltStreamLib.EventSub.Chat.Models;

public record EventMessage(
    EventType EventType,
    object? Event,
    Message Context
);
