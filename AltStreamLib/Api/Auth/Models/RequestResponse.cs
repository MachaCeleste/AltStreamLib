#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Auth.Models
{
#if NET461 || NET472 || NET481
    public class RequestResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        public RequestResponse(bool success)
        {
            this.Success = success;
        }

        public RequestResponse() { }
    }
#elif NET9_0_OR_GREATER
public record RequestResponse(
    [property: JsonPropertyName("success")] bool Success
);
#endif
}
