using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models.Events;

public record ChatPin(
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("messageId")] string MessageId,
    [property: JsonPropertyName("auhtor")] string Author,
    [property: JsonPropertyName("authorUsername")] string? AuthorUsername,
    [property: JsonPropertyName("authorImage")] string? AuthorImage,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("userColor")] string UserColor,
    [property: JsonPropertyName("pinnedBy")] string PinnedBy,
    [property: JsonPropertyName("createdAt")] string CreatedAt
);
