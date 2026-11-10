using System.Text.Json.Serialization;

namespace AltStreamLib.EventSub.Chat.Models;

public record Roles(
    [property: JsonPropertyName("broadcaster")] bool Broadcaster,
    [property: JsonPropertyName("moderator")] bool Moderator,
    [property: JsonPropertyName("channelSubscriber")] bool ChannelSubscriber,
    [property: JsonPropertyName("altstreamSubscriber")] bool AltstreamSubscriber,
    [property: JsonPropertyName("follower")] bool Follower,
    [property: JsonPropertyName("isBot")] bool IsBot
);
