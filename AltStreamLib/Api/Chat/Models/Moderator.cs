#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Chat.Models
{
#if NET481
    public class Moderator
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        public Moderator(int id, string username, string userId, string createdAt, string name, string image)
        {
            this.Id = id;
            this.Username = username;
            this.UserId = userId;
            this.CreatedAt = createdAt;
            this.Name = name;
            this.Image = image;
        }

        public Moderator() { }
    }
#elif NET9_0_OR_GREATER
    public record Moderator(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("userId")] string UserId,
        [property: JsonPropertyName("createdAt")] string CreatedAt,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("image")] string Image
    );
#endif
}
