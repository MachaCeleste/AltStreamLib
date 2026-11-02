using Newtonsoft.Json;

namespace AltStreamLib.Api.Auth.Models
{
    public class UserInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("email")]
        public string Email { get; set; }
    
        [JsonProperty("image")]
        public string Image { get; set; }
    
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("hasLinkedAccount")]
        public bool HasLinkedAccount { get; set; }

        [JsonProperty("isDiscordLinked")]
        public bool IsDiscordLinked { get; set; }

        [JsonProperty("isTwitchLinked")]
        public bool IsTwitchLinked { get; set; }

        [JsonProperty("ageVerified")]
        public bool AgeVerified { get; set; }

        [JsonProperty("discordUsername")]
        public string DiscordUsername { get; set; }

        [JsonProperty("twitchUsername")]
        public string TwitchUsername { get; set; }

        [JsonProperty("discordId")]
        public string DiscordId { get; set; }

        [JsonProperty("twitchId")]
        public string TwitchId { get; set; }

        public UserInfo(string name, string email, string image, string id, string username,
            bool hasLinkedAccount, bool isDiscordLinked, bool isTwitchLinked, bool ageVerified,
            string discordUsername, string twitchUsername, string discordId, string twitchId)
        {
            this.Name = name;
            this.Email = email;
            this.Image = image;
            this.Id = id;
            this.Username = username;
            this.HasLinkedAccount = hasLinkedAccount;
            this.IsDiscordLinked = isDiscordLinked;
            this.IsTwitchLinked = isTwitchLinked;
            this.AgeVerified = ageVerified;
            this.DiscordUsername = discordUsername;
            this.TwitchUsername = twitchUsername;
            this.DiscordId = discordId;
            this.TwitchId = twitchId;
        }

        public UserInfo() { }
    }
}
