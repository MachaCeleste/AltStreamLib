using SseClientLib;
using AltStreamLib.EventSub.Chat;
using AltStreamLib.EventSub.Chat.Models;
using AltStreamLib.EventSub.Chat.Models.Events;
using AltStreamLib.Logging;

namespace AltStreamLib.EventSub;

public class EventSubClient : IDisposable
{
    public string ChannelName { get; private set; }

    private const string _chatEndpoint = "https://altstream.online/api/chat/stream";
    private readonly string _channel;

    private SseClient? _sseClient;
    private Task? _connectionTask;
    private readonly CancellationTokenSource _shutdownCts = new();

    private int _reconnectionAttempts;
    private const int MaxReconnectionAttempts = 5;
    private readonly TimeSpan _baseReconnectDelay = TimeSpan.FromSeconds(2);

    public event Action? OnPing;
    public event Action? OnConnected;
    public event Action? OnDisconnected;

    public event Action<Message>? OnMessageReceived;

    public event Action<EventMessage>? OnMessageDeleted;
    public event Action<EventMessage>? OnMessagePinned;
    public event Action<EventMessage>? OnMessageUnPinned;
    public event Action<EventMessage>? OnHighlightReceived;
    public event Action<EventMessage>? OnRedemptionReceived;
    public event Action<EventMessage>? OnRaidStarted;
    public event Action<EventMessage>? OnRaidCanceled;
    public event Action<EventMessage>? OnRaidReceived;
    public event Action<EventMessage>? OnShoutoutReceived;
    public event Action<EventMessage>? OnClearChatReceived;

    public event Action<EventMessage>? OnUnhandledReceived;

    public EventSubClient(string channelName)
    {
        if (string.IsNullOrEmpty(channelName))
        {
            var ex = new ArgumentNullException(nameof(channelName));
            Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
            throw ex;
        }

        ChannelName = channelName;

        _channel = $"channel={channelName}";

        _sseClient = new SseClient(_chatEndpoint, _channel, null);
    }

    public async Task ConnectAsync()
    {
        Logger.Singleton?.Log(LogLevel.Info, "Starting SSE connection manager...");
        _connectionTask = MaintainConnectionAsync(_shutdownCts.Token);
        await Task.CompletedTask;
    }

    public async Task DisconnectAsync()
    {
        Logger.Singleton?.Log(LogLevel.Info, "Stopping SSE connection manager...");
        _shutdownCts.Cancel();

        if (_connectionTask is not null)
        {
            try
            {
                await _connectionTask;
            }
            catch (OperationCanceledException)
            {
                Logger.Singleton?.Log(LogLevel.Info, "Connection task canceled.");
            }
        }

        _sseClient?.Dispose();
    }

    private async Task MaintainConnectionAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await ConnectWithReconnectAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Logger.Singleton?.Log(LogLevel.Info, "Connection maintenance canceled.");
                break;
            }
            catch (Exception ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, $"Unexpected error in connection loop: {ex.Message}", ex);
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private async Task ConnectWithReconnectAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _sseClient = new SseClient(_chatEndpoint, _channel, TimeSpan.FromSeconds(45));

            SubscribeClientEvents();

            try
            {
                Logger.Singleton?.Log(LogLevel.Info, $"Attempt {_reconnectionAttempts + 1}/{MaxReconnectionAttempts} to connect...");
                await _sseClient.ConnectAsync(cancellationToken);

                _reconnectionAttempts = 0;
                Logger.Singleton?.Log(LogLevel.Info, "Connection closed by server.");
            }
            catch (OperationCanceledException)
            {
                Logger.Singleton?.Log(LogLevel.Info, "Connection canceled.");
                throw;
            }
            catch (TimeoutException ex)
            {
                Logger.Singleton?.Log(LogLevel.Warn, $"Keep-alive timeout: {ex.Message}", ex);
                _reconnectionAttempts++;
            }
            catch (HttpRequestException ex)
            {
                Logger.Singleton?.Log(LogLevel.Warn, $"Http error: {ex.Message}", ex);
                _reconnectionAttempts++;
            }
            catch (Exception ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, $"Connection error: {ex.Message}", ex);
                _reconnectionAttempts++;
            }
            finally
            {
                _sseClient?.Dispose();
                _sseClient = null;
            }

            if (_reconnectionAttempts >= MaxReconnectionAttempts)
            {
                Logger.Singleton?.Log(LogLevel.Error, $"Max reconnection attempts ({MaxReconnectionAttempts}) reached. Reconnect manually.");
                OnDisconnected?.Invoke();
                break;
            }

            var delay = _baseReconnectDelay
                .Multiply(Math.Pow(2, _reconnectionAttempts - 1))
                .Add(TimeSpan.FromMicroseconds(Random.Shared.Next(0, 1000)));

            Logger.Singleton?.Log(LogLevel.Info,
                $"Reconnecting in {delay.TotalSeconds:F1}s " +
                $"(attempt {_reconnectionAttempts}/{MaxReconnectionAttempts})...");

            try
            {
                await Task.Delay(delay, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
        }
    }

    private void SubscribeClientEvents()
    {
        if (_sseClient is null)
            return;

        _sseClient.OnConnected += () =>
        {
            Logger.Singleton?.Log(LogLevel.Info, "Connected!");
            _reconnectionAttempts = 0;
            OnConnected?.Invoke();
        };

        _sseClient.OnDisconnected += () =>
        {
            Logger.Singleton?.Log(LogLevel.Info, "Disconnected.");
            OnDisconnected?.Invoke();
        };

        _sseClient.OnRawMessageReceived += (string payload) =>
        {
            try
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
                        EventType.Highlight => OnHighlightReceived,
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
            catch (Exception ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
            }
        };

        _sseClient.OnLog += (string message) =>
        {
            Logger.Singleton?.Log(LogLevel.Info, message);
        };

        _sseClient.OnError += (string message, Exception ex) =>
        {
            Logger.Singleton?.Log(LogLevel.Error, message, ex);
        };

        _sseClient.OnPing += () =>
        {
            Logger.Singleton?.Log(LogLevel.Ping, "PING");
        };
    }

    public void Dispose()
    {
        _shutdownCts?.Cancel();
        _sseClient?.Dispose();
        _shutdownCts?.Dispose();
    }
}
