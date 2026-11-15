using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v2.Models;

public record Redemption(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("rewardId")] int RewardId,
    [property: JsonPropertyName("rewardName")] string RewardName,
    [property: JsonPropertyName("rewardCost")] int RewardCost,
    [property: JsonPropertyName("userInput")] string? UserInput,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("createdAt")] string CreatedAt,
    [property: JsonPropertyName("updatedAt")] string UpdatedAt,
    [property: JsonPropertyName("user")] RedemptionUser User
);

public enum RedemptionStatus
{
    None,
    Unfulfilled,
    Fulfilled,
    Refunded
}