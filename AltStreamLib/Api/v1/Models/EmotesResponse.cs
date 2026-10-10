using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record EmotesResponse(
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("emotes")] List<EmoteInfo> Emotes
);
