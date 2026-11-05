using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Raid(
    [property: JsonPropertyName("from")] Author From,
    [property: JsonPropertyName("viewers")] int Viewers
);
