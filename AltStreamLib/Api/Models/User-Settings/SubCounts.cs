#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.User_Settings
{
#if NET461 || NET472 || NET481
    public class SubCounts
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        public SubCounts(int total, int active)
        {
            this.Total = total;
            this.Active = active;
        }

        public SubCounts() { }
    }
#elif NET9_0_OR_GREATER
    public record SubCounts(
        [property: JsonPropertyName("total")] int Total,
        [property: JsonPropertyName("active")] int Active
    );
#endif
}
