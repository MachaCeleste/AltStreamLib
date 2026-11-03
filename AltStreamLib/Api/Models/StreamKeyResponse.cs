using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Models;

public record StreamKeyResponse(
    [property: JsonPropertyName("streamKey")] string StreamKey,
    [property: JsonPropertyName("hasStreamerKey")] bool HasStreamKey
);
