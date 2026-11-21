#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.v1
{
#if NET461 || NET472 || NET481
    public class Referer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }

        public Referer(string id, string username, string name)
        {
            this.Id = id;
            this.Username = username;
            this.Name = name;
        }

        public Referer() { }
    }
#elif NET9_0_OR_GREATER
    public record Referer(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("name")] string Name
    );
#endif
}
