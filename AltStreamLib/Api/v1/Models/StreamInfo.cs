using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record StreamInfo(
    [property: JsonPropertyName("isLive")] bool IsLive,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("viewers")] int Viewers,
    [property: JsonPropertyName("startedAt")] string StartedAt,
    [property: JsonPropertyName("game")] GameInfo Game
);
