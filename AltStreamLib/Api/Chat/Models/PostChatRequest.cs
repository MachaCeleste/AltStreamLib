using Newtonsoft.Json;

namespace AltStreamLib.Api.Chat.Models
{
    public class PostChatRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
    
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("replyToId")]
        public string ReplyToId { get; set; }

        public PostChatRequest(string channel, string message, string replyToId)
        {
            this.Channel = channel;
            this.Message = message;
            this.ReplyToId = replyToId;
        }

        public PostChatRequest() { }
    }
}
