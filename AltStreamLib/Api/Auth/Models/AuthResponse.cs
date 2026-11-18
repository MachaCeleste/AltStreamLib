#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Auth.Models
{
#if NET461 || NET472 || NET481
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
#elif NET9_0_OR_GREATER
public record AuthResponse(
    [property: JsonPropertyName("csrfToken")] string Token
);
#endif
}
