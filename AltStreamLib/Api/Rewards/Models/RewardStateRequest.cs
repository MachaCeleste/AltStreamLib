using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Rewards.Models;

public record RewardStateRequest(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("enabled")] bool Enabled
);
