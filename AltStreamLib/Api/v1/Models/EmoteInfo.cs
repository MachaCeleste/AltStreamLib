using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record EmoteInfo(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("displayOrder")] int DisplayOrder
);
