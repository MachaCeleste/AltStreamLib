using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record RewardInfo(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("cost")] int Cost,
    [property: JsonPropertyName("enabled")] bool Enabled,
    [property: JsonPropertyName("isHighlight")] bool IsHighlight,
    [property: JsonPropertyName("requireUserInput")] bool RequireUserInput,
    [property: JsonPropertyName("cooldownSeconds")] int? CooldownSeconds,
    [property: JsonPropertyName("globalCooldownSeconds")] int? GlobalCooldownSeconds,
    [property: JsonPropertyName("maxPerStream")] int? MaxPerStream,
    [property: JsonPropertyName("maxGlobalPerStream")] int? MaxGlobalPerStream
);
