using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models.Events;

public record RaidStart(
    [property: JsonPropertyName("raidId")] int RaidId,
    [property: JsonPropertyName("sourceChannel")] string SourceChannel,
    [property: JsonPropertyName("targetUsername")] string TargetUsername,
    [property: JsonPropertyName("targetDisplayName")] string TargetDisplayName,
    [property: JsonPropertyName("targetImage")] string TargetImage,
    [property: JsonPropertyName("viewers")] int Viewers,
    [property: JsonPropertyName("countdownSeconds")] int CountdownSeconds,
    [property: JsonPropertyName("startTime")] long StartTime
);
