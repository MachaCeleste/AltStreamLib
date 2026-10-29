using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Auth.Models;

public record AuthResponse(
    [property: JsonPropertyName("csrfToken")] string Token
);
