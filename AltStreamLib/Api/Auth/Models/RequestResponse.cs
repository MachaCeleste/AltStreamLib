using Newtonsoft.Json;

namespace AltStreamLib.Api.Auth.Models
{
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
}