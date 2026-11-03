using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Live.Models;

public record UpdateTitleRequest(
    [property: JsonPropertyName("key")] string Key,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("username")] string Username
);
