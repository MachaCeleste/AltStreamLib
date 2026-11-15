using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v2.Models;

public record RedemptionUser(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("displayName")] string? DisplayName,
    [property: JsonPropertyName("image")] string? Image
);
