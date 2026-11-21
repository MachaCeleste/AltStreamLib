#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Stickers
{
#if NET461 || NET472 || NET481
    public class Sticker
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("isEmote")]
        public bool IsEmote { get; set; }

        [JsonProperty("artistUsername")]
        public string ArtistUsername { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        public Sticker(int id, string userId, string username, string name, string url,
            bool isEmote, string artistUsername, int displayOrder, string createdAt)
        {
            this.Id = id;
            this.UserId = userId;
            this.Username = username;
            this.Name = name;
            this.Url = url;
            this.IsEmote = isEmote;
            this.ArtistUsername = artistUsername;
            this.DisplayOrder = displayOrder;
            this.CreatedAt = createdAt;
        }

        public Sticker() { }
    }
#elif NET9_0_OR_GREATER
    public record Sticker(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("userId")] string UserId,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("isEmote")] bool IsEmote,
        [property: JsonPropertyName("artistUsername")] string? ArtistUsername,
        [property: JsonPropertyName("displayOrder")] int DisplayOrder,
        [property: JsonPropertyName("createdAt")] string CreatedAt
    );
#endif
}
