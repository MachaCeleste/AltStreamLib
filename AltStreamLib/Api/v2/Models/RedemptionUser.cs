#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v2.Models
{
#if NET481
    public class RedemptionUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    
        [JsonProperty("image")]
        public string Image { get; set; }

        public RedemptionUser(string id, string username, string displayName, string image)
        {
            this.Id = id;
            this.Username = username;
            this.DisplayName = displayName;
            this.Image = image;
        }

        public RedemptionUser() { }
    }
#elif NET9_0_OR_GREATER
    public record RedemptionUser(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("displayName")] string? DisplayName,
        [property: JsonPropertyName("image")] string? Image
    );
#endif
}
