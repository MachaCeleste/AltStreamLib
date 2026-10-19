using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record TagsResponse(
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("tags")] string[] Tags
);
