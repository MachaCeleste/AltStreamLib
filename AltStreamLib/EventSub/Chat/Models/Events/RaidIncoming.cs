namespace AltStreamLib.EventSub.Chat.Models.Events;

public record RaidIncoming(
    string SourceUsername,
    int Viewers
);
