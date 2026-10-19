using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models.Events;

public record Redemption(
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("rewardName")] string RewardName,
    [property: JsonPropertyName("cost")] int Cost,
    [property: JsonPropertyName("pointsName")] string PointsName,
    [property: JsonPropertyName("userInput")] string? UserInput
);
