using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Author(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("displayName")] string DisplayName,
    [property: JsonPropertyName("channelName")] string ChannelName,
    [property: JsonPropertyName("pronouns")] string? Pronouns,
    [property: JsonPropertyName("image")] string? Image,
    [property: JsonPropertyName("color")] string? Color,
    [property: JsonPropertyName("roles")] Roles Roles,
    [property: JsonPropertyName("badges")] string[] Badges
);
