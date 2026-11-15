using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record Achievement(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("category")] string Category,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("isUnlocked")] bool IsUnlocked,
    [property: JsonPropertyName("unlockedAt")] string UnlockedAt,
    [property: JsonPropertyName("unlockedDetails")] string UnlockedDetails,
    [property: JsonPropertyName("lockedReason")] string LockedReason,
    [property: JsonPropertyName("progress")] Progress Progress
);

public record Progress(
    [property: JsonPropertyName("current")] int Current,
    [property: JsonPropertyName("target")] int Target
);
