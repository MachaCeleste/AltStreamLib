#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.v2
{
#if NET461 || NET472 || NET481
    public class RedemptionsResponse
    {
        [JsonProperty("redemptions")]
        public List<Redemption> Redemptions { get; set; }

        public RedemptionsResponse(List<Redemption> redemptions)
        {
            this.Redemptions = redemptions;
        }

        public RedemptionsResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record RedemptionsResponse(
        [property: JsonPropertyName("redemptions")] List<Redemption> Redemptions
    );
#endif
}
