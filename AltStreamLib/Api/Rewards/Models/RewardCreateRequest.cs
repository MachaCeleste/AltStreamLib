using Newtonsoft.Json;

namespace AltStreamLib.Api.Rewards.Models
{
    public class RewardCreateRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("description")]
        public string Description { get; set; }
    
        [JsonProperty("cost")]
        public int Cost { get; set; }
    
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

        public RewardCreateRequest(string username, string name, string description, int cost,
            bool isHighlight, bool requiresUserInput, int? cooldownSeconds, int? globalCooldownSeconds,
            int? maxPerStream, int? maxGlobalPerStream)
        {
            this.Username = username;
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
            this.IsHighlight = isHighlight;
            this.RequiresUserInput = requiresUserInput;
            this.CooldownSeconds = cooldownSeconds;
            this.GlobalCooldownSeconds = globalCooldownSeconds;
            this.MaxPerStream = maxPerStream;
            this.MaxGlobalPerStream = maxGlobalPerStream;
        }

        public RewardCreateRequest() { }
    }
}
