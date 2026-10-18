using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Chat.Models;

public record Moderator(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("createdAt")] string CreatedAt,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("image")] string Image
);
