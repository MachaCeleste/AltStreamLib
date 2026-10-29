using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Auth.Models;

public record UserInfo(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("image")] string? Image,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("hasLinkedAccount")] bool HasLinkedAccount,
    [property: JsonPropertyName("isDiscordLinked")] bool IsDiscordLinked,
    [property: JsonPropertyName("isTwitchLinked")] bool IsTwitchLinked,
    [property: JsonPropertyName("ageVerified")] bool AgeVerified,
    [property: JsonPropertyName("discordUsername")] string? DiscordUsername,
    [property: JsonPropertyName("twitchUsername")] string? TwitchUsername,
    [property: JsonPropertyName("discordId")] string? DiscordId,
    [property: JsonPropertyName("twitchId")] string? TwitchId
);
