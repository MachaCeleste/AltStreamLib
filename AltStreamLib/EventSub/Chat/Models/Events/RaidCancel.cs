using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models.Events;

public record RaidCancel(
    [property: JsonPropertyName("sourceChannel")] string SourceChannel
);
