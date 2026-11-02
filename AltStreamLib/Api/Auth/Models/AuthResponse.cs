using Newtonsoft.Json;

namespace AltStreamLib.Api.Auth.Models
{
    public class AuthResponse
    {
        [JsonProperty("csrfToken")]
        public string Token { get; set; }

        public AuthResponse(string token)
        {
            this.Token = token;
        }

        public AuthResponse() { }
    }
}