using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models.Events;

public record Shoutout(
    [property: JsonPropertyName("targetUsername")] string TargetUsername,
    [property: JsonPropertyName("targetDisplayName")] string TargetDisplayName,
    [property: JsonPropertyName("targetAvatar")] string TargetAvatar,
    [property: JsonPropertyName("targetBio")] string TargetBio,
    [property: JsonPropertyName("gameName")] string GameName,
    [property: JsonPropertyName("gameCover")] string GameCover,
    [property: JsonPropertyName("shoutedBy")] string ShoutedBy
);
