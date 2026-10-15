using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
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
}
