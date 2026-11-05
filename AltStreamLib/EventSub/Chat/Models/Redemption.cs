using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Redemption(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("rewardId")] string RewardId,
    [property: JsonPropertyName("from")] Author From,
    [property: JsonPropertyName("rewardName")] string RewardName,
    [property: JsonPropertyName("cost")] int Cost,
    [property: JsonPropertyName("pointsName")] string PointsName,
    [property: JsonPropertyName("userInput")] string? UserInput
);
