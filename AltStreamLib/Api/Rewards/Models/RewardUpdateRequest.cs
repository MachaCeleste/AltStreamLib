#if NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Rewards.Models
{
#if NET481
    public class RewardUpdateRequest
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("description")]
        public string Description { get; set; }
    
        [JsonProperty("cost")]
        public int? Cost { get; set; }
    
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    
        [JsonProperty("isHighlight")]
        public bool IsHighlight { get; set; }
    
        [JsonProperty("requiresUserInput")]
        public bool RequiresUserInput { get; set; }
    
        [JsonProperty("cooldownSeconds")]
        public int? CooldownSeconds { get; set; }
    
        [JsonProperty("globalCooldownSeconds")]
        public int? GlobalCooldownSeconds { get; set; }
    
        [JsonProperty("maxPerStream")]
        public int? MaxPerStream { get; set; }
    
        [JsonProperty("maxGlobalPerStream")]
        public int? MaxGlobalPerStream { get; set; }

        public RewardUpdateRequest(int id, string username, string name, string description,
            int cost, bool enabled, bool isHighlight, bool requiresUserInput, int? cooldownSeconds,
            int? globalCooldownSeconds, int? maxPerStream, int? maxGlobalPerStream)
        {
            this.Id = id;
            this.Username = username;
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
            this.Enabled = enabled;
            this.IsHighlight = isHighlight;
            this.RequiresUserInput = requiresUserInput;
            this.CooldownSeconds = cooldownSeconds;
            this.GlobalCooldownSeconds = globalCooldownSeconds;
            this.MaxPerStream = maxPerStream;
            this.MaxGlobalPerStream = maxGlobalPerStream;
        }

        public RewardUpdateRequest() { }
    }
#elif NET9_0_OR_GREATER
    internal record RewardUpdateRequest(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("cost")] int Cost,
        [property: JsonPropertyName("enabled")] bool Enabled,
        [property: JsonPropertyName("isHighlight")] bool IsHighlight,
        [property: JsonPropertyName("requiresUserInput")] bool RequiresUserInput,
        [property: JsonPropertyName("cooldownSeconds")] int? CooldownSeconds,
        [property: JsonPropertyName("globalCooldownSeconds")] int? GlobalCooldownSeconds,
        [property: JsonPropertyName("maxPerStream")] int? MaxPerStream,
        [property: JsonPropertyName("maxGlobalPerStream")] int? MaxGlobalPerStream
    );
#endif
}
