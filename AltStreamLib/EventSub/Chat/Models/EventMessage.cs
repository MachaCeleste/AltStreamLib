using AltStreamLib.EventSub.Chat.Models.Events;

namespace AltStreamLib.EventSub.Chat.Models;

/// <summary>
/// Event system message
/// </summary>
/// <param name="Type">Type of event being handled</param>
/// <param name="Event">Can be Null, string or EventSub/Chat/Models/Events</param>
/// <param name="Context">The original chat Message</param>
public record EventMessage(
    EventType? Type,
    object? Event,
    Message Context
);
