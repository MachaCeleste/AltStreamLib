using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Auth.Models;

public record AuthTokenRequest(
        [property: JsonPropertyName("identifier")] string Identifier,
        [property: JsonPropertyName("password")] string Password,
        [property: JsonPropertyName("csrfToken")] string CsrfToken,
        [property: JsonPropertyName("callbackUrl")] string? CallbackURl = null
);
