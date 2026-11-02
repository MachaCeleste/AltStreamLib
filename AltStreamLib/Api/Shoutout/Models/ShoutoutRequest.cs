using Newtonsoft.Json;

namespace AltStreamLib.Api.Shoutout.Models
{
    public class ShoutoutRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
    
        [JsonProperty("target")]
        public string Target { get; set; }

        public ShoutoutRequest(string channel, string target)
        {
            this.Channel = channel;
            this.Target = target;
        }

        public ShoutoutRequest() { }
    }
}
