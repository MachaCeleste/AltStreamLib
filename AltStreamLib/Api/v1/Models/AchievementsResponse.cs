#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif
using AltStreamLib.Api.v2.Models;

namespace AltStreamLib.Api.v1.Models
{
#if NET461 || NET472 || NET481
    public class AchievementsResponse
    {
        [JsonProperty("user")]
        public RedemptionUser User { get; set; }
    
        [JsonProperty("selectedBadges")]
        public string[] SelectedBadges { get; set; }
    
        [JsonProperty("achievements")]
        public List<Achievement> Achievements { get; set; }

        public AchievementsResponse(RedemptionUser user, string[] selectedBadges, List<Achievement> achievements)
        {
            this.User = user;
            this.SelectedBadges = selectedBadges;
            this.Achievements = achievements;
        }

        public AchievementsResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record AchievementsResponse(
        [property: JsonPropertyName("user")] RedemptionUser User,
        [property: JsonPropertyName("selectedBadges")] string[] SelectedBadges,
        [property: JsonPropertyName("achievements")] List<Achievement> Achievements
    );
#endif
}
