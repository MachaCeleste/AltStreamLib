using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Sticker(
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("name")] string Name
);
