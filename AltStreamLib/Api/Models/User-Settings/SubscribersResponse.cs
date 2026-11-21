#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif


namespace AltStreamLib.Api.Models.User_Settings
{
#if NET461 || NET472 || NET481
    public class SubscribersResponse
    {
        [JsonProperty("subscriptions")]
        public List<Subscriber> Subscribers { get; set; }

        [JsonProperty("counts")]
        public SubCounts Counts { get; set; }

        public SubscribersResponse(List<Subscriber> subscribers, SubCounts counts)
        {
            this.Subscribers = subscribers;
            this.Counts = counts;
        }

        public SubscribersResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record SubscribersResponse(
        [property: JsonPropertyName("subscriptions")] List<Subscriber> Subscribers,
        [property: JsonPropertyName("counts")] SubCounts Counts
    );
#endif
}
