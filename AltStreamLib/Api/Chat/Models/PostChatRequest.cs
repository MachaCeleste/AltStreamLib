#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Chat.Models
{
#if NET481
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
#elif NET9_0_OR_GREATER
    internal record PostChatRequest(
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("message")] string Message,
        [property: JsonPropertyName("replyToId")] string? ReplyToId
    );
#endif
}
