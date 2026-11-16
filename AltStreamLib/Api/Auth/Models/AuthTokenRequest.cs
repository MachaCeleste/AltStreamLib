#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
#endif
using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Auth.Models
{
#if NET481
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
#elif NET9_0_OR_GREATER
    public record AuthTokenRequest(
            [property: JsonPropertyName("identifier")] string Identifier,
            [property: JsonPropertyName("password")] string Password,
            [property: JsonPropertyName("csrfToken")] string CsrfToken,
            [property: JsonPropertyName("callbackUrl")] string? CallbackURl = null
    );
#endif
}
