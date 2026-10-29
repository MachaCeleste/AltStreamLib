using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models.Events;

public record Roles(
    [property: JsonPropertyName("broadcaster")] bool Broadcaster,
    [property: JsonPropertyName("moderator")] bool Moderator,
    [property: JsonPropertyName("subscriber")] bool Subscriber,
    [property: JsonPropertyName("supporter")] bool Supporter
);
