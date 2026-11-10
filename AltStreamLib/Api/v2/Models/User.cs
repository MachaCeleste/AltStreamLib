using System.Text.Json.Serialization;
using AltStreamLib.EventSub.Chat.Models;

namespace AltStreamLib.Api.v2.Models;

public record User(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("DisplayName")] string DisplayName,
    [property: JsonPropertyName("channelName")] string ChannelName,
    [property: JsonPropertyName("pronouns")] string Pronouns,
    [property: JsonPropertyName("image")] string Image,
    [property: JsonPropertyName("color")] string Color,
    [property: JsonPropertyName("createdAt")] string CreatedAt,
    [property: JsonPropertyName("roles")] Roles Roles
);
