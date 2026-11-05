using Newtonsoft.Json;

namespace AltStreamLib.Api.Chat.Models
{
    public class PostChatRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
    
        [JsonProperty("message")]
        public string Message { get; set; }

        public PostChatRequest(string channel, string message)
        {
            this.Channel = channel;
            this.Message = message;
        }

        public PostChatRequest() { }
    }
}
