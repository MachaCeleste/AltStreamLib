#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.EventSub.Chat.Models
{
#if NET461 || NET472 || NET481
    public class Reply
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
    
        [JsonProperty("messageAuthorDisplay")]
        public string MessageAuthorDisplayName { get; set; }
    
        [JsonProperty("messageAuthorChannelName")]
        public string MessageAuthorChannelName { get; set; }

        public Reply(string messageId, string messageAuthorDisplayName, string messageAuthorChannelName)
        {
            this.MessageId = messageId;
            this.MessageAuthorDisplayName = messageAuthorDisplayName;
            this.MessageAuthorChannelName = messageAuthorChannelName;
        }

        public Reply() { }
    }
#elif NET9_0_OR_GREATER
    public record Reply(
        [property: JsonPropertyName("messageId")] string MessageId,
        [property: JsonPropertyName("messageAuthorDisplayName")] string MessageAuthorDisplayName,
        [property: JsonPropertyName("messageAuthorChannelName")] string MessageAuthorChannelName
    );
#endif
}
