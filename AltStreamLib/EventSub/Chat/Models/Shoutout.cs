using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Shoutout(
    [property: JsonPropertyName("target")] Author Target
);
