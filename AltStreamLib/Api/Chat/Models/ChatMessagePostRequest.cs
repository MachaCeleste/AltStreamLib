using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Chat.Models;

internal record ChatMessagePostRequest(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("author")] string Author,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("replyToId")] string? ReplyToId,
    [property: JsonPropertyName("replyToAuthor")] string? ReplyToAuthor
);
