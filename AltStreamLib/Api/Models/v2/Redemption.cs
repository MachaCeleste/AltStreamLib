#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.v2
{
#if NET461 || NET472 || NET481
    public class Redemption
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("rewardId")]
        public int RewardId { get; set; }
    
        [JsonProperty("rewardName")]
        public string RewardName { get; set; }
    
        [JsonProperty("rewardCost")]
        public int RewardCost { get; set; }
    
        [JsonProperty("userInput")]
        public string UserInput { get; set; }
    
        [JsonProperty("status")]
        public string Status { get; set; }
    
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
    
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    
        [JsonProperty("user")]
        public RedemptionUser User { get; set; }

        public Redemption(int id, int rewardId, string rewardName, int rewardCost, string userInput,
            string status, string createdAt, string updatedAt, RedemptionUser user)
        {
            this.Id = id;
            this.RewardId = rewardId;
            this.RewardName = rewardName;
            this.RewardCost = rewardCost;
            this.UserInput = userInput;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.User = user;
        }

        public Redemption() { }
    }
#elif NET9_0_OR_GREATER
    public record Redemption(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("rewardId")] int RewardId,
        [property: JsonPropertyName("rewardName")] string RewardName,
        [property: JsonPropertyName("rewardCost")] int RewardCost,
        [property: JsonPropertyName("userInput")] string? UserInput,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("createdAt")] string CreatedAt,
        [property: JsonPropertyName("updatedAt")] string UpdatedAt,
        [property: JsonPropertyName("user")] RedemptionUser User
    );
#endif

    public enum RedemptionStatus
    {
        None,
        Unfulfilled,
        Fulfilled,
        Refunded
    }
}