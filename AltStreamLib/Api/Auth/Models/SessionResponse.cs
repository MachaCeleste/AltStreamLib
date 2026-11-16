#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Auth.Models
{
#if NET481
    public class SessionResponse
    {
        [JsonProperty("user")]
        public UserInfo User { get; set; }
    
        [JsonProperty("expires")]
        public string Expires { get; set; }

        public SessionResponse(UserInfo user, string expires)
        {
            this.User = user;
            this.Expires = expires;
        }

        public SessionResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record SessionResponse(
        [property: JsonPropertyName("user")] UserInfo User,
        [property: JsonPropertyName("expires")] string Expires
    );
#endif
}
