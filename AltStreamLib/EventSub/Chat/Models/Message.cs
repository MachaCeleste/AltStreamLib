using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("sentAt")]
        public long SentAt { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("authorUsername")]
        public string AuthorUsername { get; set; }

        [JsonProperty("authorImage")]
        public string AuthorImage { get; set; }

        [JsonProperty("replyToId")]
        public string ReplyToId { get; set; }

        [JsonProperty("replyToAuthor")]
        public string ReplyToAuthor { get; set; }

        [JsonProperty("replyToUsername")]
        public string ReplyToUsername { get; set; }

        [JsonProperty("stickerUrl")]
        public string StickerUrl { get; set; }

        [JsonProperty("userColor")]
        public string UserColor { get; set; }

        public Message(
            string id, string author, string text, string source, long sentAt,
            string channel, string authorUsername, string authorImage,
            string replyToId, string replyToAuthor, string replyToUsername,
            string stickerUrl, string userColor)
        {
            this.Id = id;
            this.Author = author;
            this.Text = text;
            this.Source = source;
            this.SentAt = sentAt;
            this.Channel = channel;
            this.AuthorUsername = authorUsername;
            this.AuthorImage = authorImage;
            this.ReplyToId = replyToId;
            this.ReplyToAuthor = replyToAuthor;
            this.ReplyToUsername = replyToUsername;
            this.StickerUrl = stickerUrl;
            this.UserColor = userColor;
        }

        public Message() { }
    }
}
