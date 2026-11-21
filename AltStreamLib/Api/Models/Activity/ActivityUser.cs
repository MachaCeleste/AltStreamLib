#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Activity
{
#if NET461 || NET472 || NET481
    public class ActivityUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        public ActivityUser(string username, string name, string image)
        {
            this.Username = username;
            this.Name = name;
            this.Image = image;
        }

        public ActivityUser() { }
    }
#elif NET9_0_OR_GREATER
    public record ActivityUser(
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("image")] string Image
    );
#endif
}
