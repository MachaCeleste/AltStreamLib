using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Raid(
    [property: JsonPropertyName("to")] Author? To,
    [property: JsonPropertyName("from")] Author? From,
    [property: JsonPropertyName("viewers")] int Viewers,
    [property: JsonPropertyName("countdownSeconds")] int? CountdownSeconds,
    [property: JsonPropertyName("startTime")] long? StartTime
);
