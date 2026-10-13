using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record UserSettingsResponse(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("image")] string Image,
    [property: JsonPropertyName("bio")] string Bio,
    [property: JsonPropertyName("pronouns")] string Pronouns,
    [property: JsonPropertyName("blueskyUrl")] string BlueskyUrl,
    [property: JsonPropertyName("websiteUrl")] string WebsiteUrl,
    [property: JsonPropertyName("discordUrl")] string DiscordUrl,
    [property: JsonPropertyName("kofiUrl")] string KofiUrl,
    [property: JsonPropertyName("chatColor")] string ChatColor,
    [property: JsonPropertyName("gamingShelf")] List<GameInfo> GamingShelf,
    [property: JsonPropertyName("isSubscriber")] bool IsSubscriber,
    [property: JsonPropertyName("isAltStreamSupporter")] bool IsAltStreamSupporter,
    [property: JsonPropertyName("isChannelSupporter")] bool IsChannelSupporter,
    [property: JsonPropertyName("isSiteAdmin")] bool IsSiteAdmin,
    [property: JsonPropertyName("testerBadge")] string TesterBadge,
    [property: JsonPropertyName("channelPointsName")] string ChannelPointsName
);
