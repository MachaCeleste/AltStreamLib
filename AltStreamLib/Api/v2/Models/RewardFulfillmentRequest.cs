#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v2.Models
{
#if NET461 || NET472 || NET481
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
#elif NET9_0_OR_GREATER
    public record RewardFulfillmentRequest(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("action")] string Action
    );
#endif

    public enum Fulfillment
    {
        Fulfill,
        Refund
    }
}