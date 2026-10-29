using System.Text.Json;
using System.Text.Json.Serialization;
using AltStreamLib.EventSub.Chat.Models.Events;

namespace AltStreamLib.EventSub.Chat.Models;

public record Message(
    [property: JsonPropertyName("type")] MessageType Type,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("author")] string Author,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("sentAt")] long SentAt,
    [property: JsonPropertyName("channel")] string? Channel,
    [property: JsonPropertyName("authorUsername")] string? AuthorUsername,
    [property: JsonPropertyName("authorImage")] string? AuthorImage,
    [property: JsonPropertyName("authorPronouns")] string AuthorPronouns,
    [property: JsonPropertyName("stickerUrl")] string? StickerUrl,
    [property: JsonPropertyName("stickerName")] string? StickerName,
    [property: JsonPropertyName("userColor")] string? UserColor,
    [property: JsonPropertyName("color")] string? Color,
    [property: JsonPropertyName("isSubscriber")] bool? IsSubscriber,
    [property: JsonPropertyName("roles")] Roles Roles,
    [property: JsonPropertyName("badges")] string[]? Badges,
    [property: JsonPropertyName("data")] JsonElement? Data,
    [property: JsonPropertyName("source")] string? Source,
    [property: JsonPropertyName("replyToId")] string? ReplyToId,
    [property: JsonPropertyName("replyToAuthor")] string? ReplyToAuthor,
    [property: JsonPropertyName("replyToUsername")] string? ReplyToUsername,
    [property: JsonPropertyName("replyToPronouns")] string? ReplyToPronouns,
    [property: JsonPropertyName("isModerator")] bool? IsModerator,
    [property: JsonPropertyName("isChannelSupporter")] bool? IsChannelSupporter
);
