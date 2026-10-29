using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Shoutout.Models;

public record ShoutoutRequest(
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("target")] string Target
);
