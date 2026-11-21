#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.v1
{
#if NET461 || NET472 || NET481
    public class Achievement
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("type")]
        public string Type { get; set; }
    
        [JsonProperty("category")]
        public string Category { get; set; }
    
        [JsonProperty("description")]
        public string Description { get; set; }
    
        [JsonProperty("isUnlocked")]
        public bool IsUnlocked { get; set; }
    
        [JsonProperty("unlockedAt")]
        public string UnlockedAt { get; set; }
    
        [JsonProperty("unlockedDetails")]
        public string UnlockedDetails { get; set; }
    
        [JsonProperty("lockedReason")]
        public string LockedReason { get; set; }
    
        [JsonProperty("progress")]
        public Progress Progress { get; set; }

        public Achievement(string id, string name, string type, string category, string description,
            bool isUnlocked, string unlockedAt, string unlockedDetails, string lockedReason, Progress progress)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Category = category;
            this.Description = description;
            this.IsUnlocked = isUnlocked;
            this.UnlockedAt = unlockedAt;
            this.UnlockedDetails = unlockedDetails;
            this.LockedReason = lockedReason;
            this.Progress = progress;
        }

        public Achievement() { }
    }

    public class Progress
    {
        [JsonProperty("current")]
        public int Current { get; set; }
    
        [JsonProperty("target")]
        public int Target { get; set; }

        public Progress(int current, int target)
        {
            this.Current = current;
            this.Target = target;
        }

        public Progress() { }
    }
#elif NET9_0_OR_GREATER
    public record Achievement(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("category")] string Category,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("isUnlocked")] bool IsUnlocked,
        [property: JsonPropertyName("unlockedAt")] string UnlockedAt,
        [property: JsonPropertyName("unlockedDetails")] string UnlockedDetails,
        [property: JsonPropertyName("lockedReason")] string LockedReason,
        [property: JsonPropertyName("progress")] Progress Progress
    );

    public record Progress(
        [property: JsonPropertyName("current")] int Current,
        [property: JsonPropertyName("target")] int Target
    );
#endif
}
