using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Rewards.Models;

internal record RewardOrderRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("orderedIds")] int[] OrderedIds
);
