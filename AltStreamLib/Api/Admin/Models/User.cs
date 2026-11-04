using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Admin.Models;

public record User(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("image")] string Image,
            [property: JsonPropertyName("country")] string Country,
            [property: JsonPropertyName("countryCode")]string CountryCode,
            [property: JsonPropertyName("flag")] string Flag,
            [property: JsonPropertyName("joinedAt")]string JoinedAt
);
