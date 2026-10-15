using SseClientLib;
using AltStreamLib.EventSub.Chat;
using AltStreamLib.EventSub.Chat.Models;
using AltStreamLib.EventSub.Chat.Models.Events;
using AltStreamLib.Logging;

namespace AltStreamLib.EventSub;

public class EventSubClient : IDisposable
{
    public string ChannelName { get; private set; }

    private readonly CancellationTokenSource _cts = new();

    private readonly SseClient _sseClient;

    public event Action<Message>? OnMessageReceived;

    public event Action<EventMessage>? OnMessageDeleted;
    public event Action<EventMessage>? OnMessagePinned;
    public event Action<EventMessage>? OnMessageUnPinned;
    public event Action<EventMessage>? OnRedemptionReceived;
    public event Action<EventMessage>? OnRaidStarted;
    public event Action<EventMessage>? OnRaidCanceled;
    public event Action<EventMessage>? OnRaidReceived;
    public event Action<EventMessage>? OnShoutoutReceived;
    public event Action<EventMessage>? OnClearChatReceived;

    public event Action<EventMessage>? OnUnhandledReceived;

    public EventSubClient(string channelName)
    {
        ChannelName = channelName;

        string chatEndpoint = "https://altstream.online/api/chat/stream";

        var channel = $"channel={channelName}";

        _sseClient = new SseClient(chatEndpoint, channel);
        _sseClient.OnLog += OnClientLog;
        _sseClient.OnRawMessageReceived += OnChatPayloadReceived;
    }

    public async Task ConnectAsync() =>
        await _sseClient.ConnectAsync(_cts.Token);

    public async Task DisconnectAsync() =>
        _cts.Cancel();

    private void OnClientLog(string message) =>
        Logger.Singleton?.Log(LogLevel.Info, message);

    private void OnChatPayloadReceived(string payload)
    {
        if (!ChatHandler.TryDeserializeChatPayload(payload, out var message) || message is null)
            return;
        
        if (message is Message msg)
        {
            OnMessageReceived?.Invoke(msg);
            return;
        }
        else if (message is EventMessage eventMsg)
        {
            var handler = eventMsg.EventType switch
            {
                EventType.DeleteMessage => OnMessageDeleted,
                EventType.Pin => OnMessagePinned,
                EventType.Unpin => OnMessageUnPinned,
                EventType.Redeem => OnRedemptionReceived,
                EventType.RaidStart => OnRaidStarted,
                EventType.RaidCancel => OnRaidCanceled,
                EventType.RaidReceived => OnRaidReceived,
                EventType.Shoutout => OnShoutoutReceived,
                EventType.ClearChat => OnClearChatReceived,
                _ => OnUnhandledReceived
            };

            handler?.Invoke(eventMsg);
        }
    }

    public void Dispose()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _sseClient?.Dispose();
    }
}
