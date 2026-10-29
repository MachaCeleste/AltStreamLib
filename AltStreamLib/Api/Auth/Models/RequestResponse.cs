using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Auth.Models;

public record RequestResponse(
    [property: JsonPropertyName("success")] bool Success
);
