using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Reply(
    [property: JsonPropertyName("messageId")] string MessageId,
    [property: JsonPropertyName("messageAuthorDisplayName")] string MessageAuthorDisplayName,
    [property: JsonPropertyName("messageAuthorChannelName")] string MessageAuthorChannelName
);
