using Newtonsoft.Json;

namespace AltStreamLib.Api.Chat.Models
{
    public class ChatMessagePostRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("channel")]
        public string Channel { get; set; }
    
        [JsonProperty("author")]
        public string Author { get; set; }
    
        [JsonProperty("text")]
        public string Text { get; set; }
    
        [JsonProperty("replyToId")]
        public string ReplyToId { get; set; }
    
        [JsonProperty("replyToAuthor")]
        public string ReplyToAuthor { get; set; }

        public ChatMessagePostRequest(string id, string channel, string author, string text, string replyToId, string replyToAuthor)
        {
            this.Id = id;
            this.Channel = channel;
            this.Author = author;
            this.Text = text;
            this.ReplyToId = replyToId;
            this.ReplyToAuthor = replyToAuthor;
        }

        public ChatMessagePostRequest() { }
    }
}
