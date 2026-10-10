using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record PanelInfo(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("slug")] string Slug,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("content")] string Content,
    [property: JsonPropertyName("displayOrder")] int DisplayOrder
);
