using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Rewards.Models;

internal record RewardCreateRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("cost")] int Cost,
    [property: JsonPropertyName("isHighlight")] bool IsHighlight,
    [property: JsonPropertyName("requiresUserInput")] bool RequiresUserInput,
    [property: JsonPropertyName("cooldownSeconds")] int? CooldownSeconds,
    [property: JsonPropertyName("globalCooldownSeconds")] int? GlobalCooldownSeconds,
    [property: JsonPropertyName("maxPerStream")] int? MaxPerStream,
    [property: JsonPropertyName("maxGlobalPerStream")] int? MaxGlobalPerStream
);
