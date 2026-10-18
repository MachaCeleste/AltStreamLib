using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Chat.Models;

public record ModResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("moderators")] List<Moderator> Moderators
);
