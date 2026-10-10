using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record RewardsResponse(
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("rewards")] List<RewardInfo> Rewards
);
