using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class ChatPin
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("messageId")]
        public int MessageId { get; set; }

        [JsonProperty("auhtor")]
        public string Author { get; set; }

        [JsonProperty("authorUsername")]
        public string AuthorUsername { get; set; }

        [JsonProperty("authorImage")]
        public string AuthorImage { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("stickerUrl")]
        public string StickerUrl { get; set; }

        [JsonProperty("userColor")]
        public string UserColor { get; set; }

        [JsonProperty("pinnedBy")]
        public string PinnedBy { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        public ChatPin(
            string channel, int messageId, string author, string authorUsername,
            string authorImage, string text, string stickerUrl,
            string userColor, string pinnedBy, string createdAt)
        {
            this.Channel = channel;
            this.MessageId = messageId;
            this.Author = author;
            this.AuthorUsername = authorUsername;
            this.AuthorImage = authorImage;
            this.Text = text;
            this.StickerUrl = stickerUrl;
            this.UserColor = userColor;
            this.PinnedBy = pinnedBy;
            this.CreatedAt = createdAt;
        }

        public ChatPin() { }
    }
}
