using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Message(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("sticker")] Sticker? Sticker
);
