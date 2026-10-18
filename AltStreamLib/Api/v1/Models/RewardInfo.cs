using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AltStreamLib.Api.v1.Models
{
    public class RewardInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("isHighlight")]
        public bool IsHighlight { get; set; }

        [JsonProperty("requireUserInput")]
        public bool RequireUserInput { get; set; }

        [JsonProperty("cooldownSeconds")]
        public int? CooldownSeconds { get; set; }

        [JsonProperty("globalCooldownSeconds")]
        public int? GlobalCooldownSeconds { get; set; }

        [JsonProperty("maxPerStream")]
        public int? MaxPerStream { get; set; }

        [JsonProperty("maxGlobalPerStream")]
        public int? MaxGlobalPerStream { get; set; }

        public RewardInfo(
            int id, string name, string description, int cost, bool enabled,
            bool isHighlight, bool requiresUserInput, int? cooldownSeconds,
            int? globalCooldownSeconds, int? maxPerStream, int? maxGlobalPerStream)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
            this.Enabled = enabled;
            this.IsHighlight = isHighlight;
            this.RequireUserInput = requiresUserInput;
            this.CooldownSeconds = cooldownSeconds;
            this.GlobalCooldownSeconds = globalCooldownSeconds;
            this.MaxPerStream = maxPerStream;
            this.MaxGlobalPerStream = maxGlobalPerStream;
        }

        public RewardInfo() { }
    }
}
