#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Live
{
#if NET461 || NET472 || NET481
    public class UpdateTitleRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    
        [JsonProperty("title")]
        public string Title { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }

        public UpdateTitleRequest(string key, string title, string username)
        {
            this.Key = key;
            this.Title = title;
            this.Username = username;
        }

        public UpdateTitleRequest() { }
    }
#elif NET9_0_OR_GREATER
    public record UpdateTitleRequest(
        [property: JsonPropertyName("key")] string Key,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("username")] string Username
    );
#endif
}
