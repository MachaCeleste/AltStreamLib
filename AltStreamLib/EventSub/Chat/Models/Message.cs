using AltStreamLib.EventSub.Chat.Models.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class Message
    {
        [JsonProperty("type")]
        public MessageType Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("sentAt")]
        public long SentAt { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("authorUsername")]
        public string AuthorUsername { get; set; }

        [JsonProperty("authorImage")]
        public string AuthorImage { get; set; }

        [JsonProperty("authorPronouns")]
        public string AuthorPronouns { get; set; }

        [JsonProperty("stickerUrl")]
        public string StickerUrl { get; set; }

        [JsonProperty("stickerName")]
        public string StickerName { get; set; }

        [JsonProperty("userColor")]
        public string UserColor { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("isSubscriber")]
        public string IsSubscriber { get; set; }

        [JsonProperty("roles")]
        public Roles Roles { get; set; }
    
        [JsonProperty("badges")]
        public string[] Badges { get; set; }
    
        [JsonProperty("data")]
        public JToken Data { get; set; }
    
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("replyToId")]
        public string ReplyToId { get; set; }

        [JsonProperty("replyToAuthor")]
        public string ReplyToAuthor { get; set; }

        [JsonProperty("replyToUsername")]
        public string ReplyToUsername { get; set; }

        [JsonProperty("replyToPronouns")]
        public string ReplyToPronouns { get; set; }
    
        [JsonProperty("isModerator")]
        public bool IsModerator { get; set; }
    
        [JsonProperty("isChannelSupporter")]
        public bool IsChannelSupporter { get; set; }

        public Message(MessageType type,
            string id, string author, string text, long sentAt, string channel,
            string authorUsername, string authorImage, string authorPronouns,
            string stickerUrl, string stickerName, string userColor, string color,
            string isSubscriber, Roles roles, string[] badges,
            JToken data, string source, string replyToId, string replyToAuthor,
            string replyToUsername, string replyToPronouns, bool isModerator, bool isChannelSupporter)
        {
            this.Type = type;
            this.Id = id;
            this.Author = author;
            this.Text = text;
            this.SentAt = sentAt;
            this.Channel = channel;
            this.AuthorUsername = authorUsername;
            this.AuthorImage = authorImage;
            this.AuthorPronouns = authorPronouns;
            this.StickerUrl = stickerUrl;
            this.StickerName = stickerName;
            this.UserColor = userColor;
            this.Color = color;
            this.IsSubscriber = isSubscriber;
            this.Roles = roles;
            this.Badges = badges;
            this.Data = data;
            this.Source = source;
            this.ReplyToId = replyToId;
            this.ReplyToAuthor = replyToAuthor;
            this.ReplyToUsername = replyToUsername;
            this.ReplyToPronouns = replyToPronouns;
            this.IsModerator = isModerator;
            this.IsChannelSupporter = isChannelSupporter;
        }

        public Message() { }
    }
}
