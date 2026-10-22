using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models.Events;

public record KofiEvent(
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("amount")] string Amount,
    [property: JsonPropertyName("currency")] string Currency,
    [property: JsonPropertyName("message")] string? Message,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("tierName")] string? TierName,
    [property: JsonPropertyName("isFirstSubscriptionPayment")] bool IsFirstSubscriptionPayment,
    [property: JsonPropertyName("items")] string? Items
);
