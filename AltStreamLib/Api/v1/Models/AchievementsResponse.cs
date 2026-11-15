using AltStreamLib.Api.v2.Models;
using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record AchievementsResponse(
    [property: JsonPropertyName("user")] RedemptionUser User,
    [property: JsonPropertyName("selectedBadges")] string[] SelectedBadges,
    [property: JsonPropertyName("achievements")] List<Achievement> Achievements
);
