using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record GameInfo(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("slug")] string Slug,
    [property: JsonPropertyName("coverUrl")] string CoverUrl
);
