using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record Referer(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("name")] string Name
);
