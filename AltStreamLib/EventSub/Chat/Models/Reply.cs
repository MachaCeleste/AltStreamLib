using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
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
}
