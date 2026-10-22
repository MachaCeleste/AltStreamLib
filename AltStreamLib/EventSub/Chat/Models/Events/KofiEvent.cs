using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class KofiEvent
    {
        [JsonProperty("from")]
        public string From { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("amount")]
        public string Amount { get; set; }
    
        [JsonProperty("currency")]
        public string Currency { get; set; }
    
        [JsonProperty("message")]
        public string Message { get; set; }
    
        [JsonProperty("type")]
        public string Type { get; set; }
    
        [JsonProperty("tierName")]
        public string TierName { get; set; }
    
        [JsonProperty("isFirstSubscriptionPayment")]
        public bool IsFirstSubscriptionPayment { get; set; }
    
        [JsonProperty("items")]
        public string Items { get; set; }

        public KofiEvent(
            string from, string username, string amount,
            string currency, string message, string type,
            string tierName, bool isFirstSubscriptionPayment, string items)
        {
            this.From = from;
            this.Username = username;
            this.Amount = amount;
            this.Currency = currency;
            this.Message = message;
            this.Type = type;
            this.TierName = tierName;
            this.IsFirstSubscriptionPayment = isFirstSubscriptionPayment;
            this.Items = items;
        }

        public KofiEvent() { }
    }
}
