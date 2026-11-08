using Newtonsoft.Json;

namespace AltStreamLib.Api.v2.Models
{
    public class RewardFulfillmentRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("channel")]
        public string Channel { get; set; }
    
        [JsonProperty("action")]
        public string Action { get; set; }

        public RewardFulfillmentRequest(int id, string channel, string action)
        {
            this.Id = id;
            this.Channel = channel;
            this.Action = action;
        }

        public RewardFulfillmentRequest() { }
    }
}

public enum Fulfillment
{
    Fulfill,
    Refund
}
