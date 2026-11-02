using Newtonsoft.Json;

namespace AltStreamLib.Api.Rewards.Models
{
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
}
