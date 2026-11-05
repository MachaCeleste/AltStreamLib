using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
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
}
