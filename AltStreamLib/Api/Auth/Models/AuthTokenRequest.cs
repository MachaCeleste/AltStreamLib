using Newtonsoft.Json;

namespace AltStreamLib.Api.Auth.Models
{
    public class AuthTokenRequest
    {

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("csrfToken")]
        public string CsrfToken { get; set; }

        [JsonProperty("callbackUrl")]
        public string CallbackURl { get; set; } = null;

        public AuthTokenRequest(string identifier, string password, string csrfToken, string callbackURl = null)
        {
            this.Identifier = identifier;
            this.Password = password;
            this.CsrfToken = csrfToken;
            this.CallbackURl = callbackURl;
        }

        public AuthTokenRequest() { }
    }
}