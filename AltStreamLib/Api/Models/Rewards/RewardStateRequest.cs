#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Rewards
{
#if NET461 || NET472 || NET481
    public class RewardStateRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        public RewardStateRequest(int id, string username, bool enabled)
        {
            this.Id = id;
            this.Username = username;
            this.Enabled = enabled;
        }

        public RewardStateRequest() { }
    }
#elif NET9_0_OR_GREATER
    public record RewardStateRequest(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("enabled")] bool Enabled
    );
#endif
}
