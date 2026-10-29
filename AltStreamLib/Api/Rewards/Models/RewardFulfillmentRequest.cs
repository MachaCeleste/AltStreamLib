using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Rewards.Models;

public record RewardFulfillmentRequest(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("action")] string Action
);

public enum Fulfillment
{
    Fulfill,
    Refund
}