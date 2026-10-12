using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record ChannelResponse(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("displayName")] string DisplayName,
    [property: JsonPropertyName("avatarUrl")] string AvatarUrl,
    [property: JsonPropertyName("bio")] string Bio,
    [property: JsonPropertyName("createdAt")] string CreatedAt,
    [property: JsonPropertyName("stream")] StreamInfo Stream
);
