#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET481
    public class Kofi
    {
        [JsonProperty("from")]
        public string From { get; set; }
    
        [JsonProperty("amount")]
        public string Amount { get; set; }
    
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    
        [JsonProperty("message")]
        public string Message { get; set; }
    
        [JsonProperty("tierName")]
        public string TierName { get; set; }
    
        [JsonProperty("isFirstSubscriptionPayment")]
        public bool IsFirstSubscriptionPayment { get; set; }
    
        [JsonProperty("items")]
        public string Items { get; set; }

        public Kofi(string from, string amount, string currencyCode, string message,
            string tierName, bool isFirstSubscriptionPayment, string items)
        {
            this.From = from;
            this.Amount = amount;
            this.CurrencyCode = currencyCode;
            this.Message = message;
            this.TierName = tierName;
            this.IsFirstSubscriptionPayment = isFirstSubscriptionPayment;
            this.Items = items;
        }

        public Kofi() { }
    }
#elif NET9_0_OR_GREATER
    public record Kofi(
        [property: JsonPropertyName("from")] string From,
        [property: JsonPropertyName("amount")] string Amount,
        [property: JsonPropertyName("currencyCode")] string CurrencyCode,
        [property: JsonPropertyName("message")] string? Message,
        [property: JsonPropertyName("tierName")] string? TierName,
        [property: JsonPropertyName("isFirstSubscriptionPayment")] bool? IsFirstSubscriptionPayment,
        [property: JsonPropertyName("items")] string? Items
    );
#endif
}
