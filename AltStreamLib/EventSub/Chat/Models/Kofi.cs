using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Kofi(
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("amount")] string Amount,
    [property: JsonPropertyName("currencyCode")] string CurrencyCode,
    [property: JsonPropertyName("message")] string? Message,
    [property: JsonPropertyName("tierName")] string? TierName,
    [property: JsonPropertyName("isFirstSubscriptionPayment")] bool? IsFirstSubscriptionPayment,
    [property: JsonPropertyName("items")] string? Items
);
