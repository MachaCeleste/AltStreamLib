using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Auth.Models;

public record SessionResponse(
    [property: JsonPropertyName("user")] UserInfo User,
    [property: JsonPropertyName("expires")] string Expires
);
