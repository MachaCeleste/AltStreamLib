#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET481
    public class ApiResponse<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            this.Data = data;
        }

        public ApiResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record ApiResponse<T>(
        [property: JsonPropertyName("data")] T Data
    );
#endif
}
