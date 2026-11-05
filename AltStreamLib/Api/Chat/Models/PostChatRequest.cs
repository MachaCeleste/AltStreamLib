using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Chat.Models;

internal record PostChatRequest(
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("message")] string Message
);
