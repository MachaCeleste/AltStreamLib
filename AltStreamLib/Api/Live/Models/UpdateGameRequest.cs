using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Live.Models;

public record UpdateGameRequest(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("igdbId")] int IgdbId,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("slug")] string Slug,
    [property: JsonPropertyName("coverUrl")] string? CoverUrl,
    [property: JsonPropertyName("steamAppId")] string? SteamAppId,
    [property: JsonPropertyName("summary")] string? Summary,
    [property: JsonPropertyName("streamKey")] string? StreamKey,
    [property: JsonPropertyName("username")] string? Username,
    [property: JsonPropertyName("usesAiStreamerTools")] bool? UsesAiStreamerTools,
    [property: JsonPropertyName("aiStreamerToolsDetails")] string? AiStreamerToolsDetails
);
