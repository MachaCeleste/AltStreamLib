using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Message(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("author")] string Author,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("source")] string Source,
    [property: JsonPropertyName("sentAt")] long SentAt,
    [property: JsonPropertyName("channel")] string? Channel,
    [property: JsonPropertyName("authorUsername")] string? AuthorUsername,
    [property: JsonPropertyName("authorImage")] string? AuthorImage,
    [property: JsonPropertyName("replyToId")] string? ReplyToId,
    [property: JsonPropertyName("replyToAuthor")] string? ReplyToAuthor,
    [property: JsonPropertyName("replyToUsername")] string? ReplyToUsername,
    [property: JsonPropertyName("stickerUrl")] string? StickerUrl,
    [property: JsonPropertyName("userColor")] string? UserColor
);
