using Newtonsoft.Json;

namespace AltStreamLib.Api.Auth.Models
{
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
}
