using System.Text.Json;
using System.Reflection;
using System.Diagnostics;
using SseClientLib;
using AltStreamLib.Api;
using AltStreamLib.EventSub.Chat.Models;
using AltStreamLib.Logging;
using AltStreamLib.Utils;

namespace AltStreamLib.EventSub;

public class EventSubClient : IDisposable
{
    public string ChannelName { get; private set; }

    private readonly SseClient? _sseClient;
    private Task? _connectionTask;
    private CancellationTokenSource? _shutdownCts;

    private int _reconnectionAttempts;
    private const int MaxReconnectionAttempts = 5;
    private readonly TimeSpan _baseReconnectDelay = TimeSpan.FromSeconds(60);

    #region Events
    /// <summary>
    /// Called on SSE Client Connected
    /// </summary>
    public event Action? OnConnected;

    /// <summary>
    /// Called when SSE Client is in timeout but attempting reconnect
    /// </summary>
    public event Action? OnTimeout;

    /// <summary>
    /// Called when SSE Client has stood down and cancels the CTS token
    /// </summary>
    public event Action? OnDisconnected;

    /// <summary>
    /// Called when a Message is received
    /// </summary>
    public event Action<Data>? OnMessageReceived;

    /// <summary>
    /// Called when a Reply is received
    /// </summary>
    public event Action<Data>? OnReplyReceived;

    /// <summary>
    /// Called when a MessageDeleted event is received
    /// </summary>
    public event Action<Data>? OnMessageDeleted;

    /// <summary>
    /// Called when a MessagePinned event is received
    /// </summary>
    public event Action<Data>? OnMessagePinned;

    /// <summary>
    /// Called when a MessageUnpinned event is received
    /// </summary>
    public event Action<Data>? OnMessageUnPinned;

    /// <summary>
    /// Called when a HighlightMessage event is received
    /// </summary>
    public event Action<Data>? OnHighlightReceived;

    /// <summary>
    /// Called when a Redemption event is received
    /// </summary>
    public event Action<Data>? OnRedemptionReceived;

    /// <summary>
    /// Called when a Follow event is received
    /// <para>Requires auth to see</para>
    /// </summary>
    //public event Action<Data>? OnFollowReceived;

    /// <summary>
    /// Called when a KoFiTip event is received
    /// </summary>
    public event Action<Data>? OnTipReceived;

    /// <summary>
    /// Called when a KoFiSubscription event is received
    /// </summary>
    public event Action<Data>? OnSubscriptionReceived;

    /// <summary>
    /// Called when a KoFiShop event is received
    /// </summary>
    public event Action<Data>? OnShopReceived;

    /// <summary>
    /// Called when a RaidStart event is received
    /// </summary>
    //public event Action<Data>? OnRaidStarted;

    /// <summary>
    /// Called when a RaidCanceled event is received
    /// </summary>
    //public event Action<Data>? OnRaidCanceled;

    /// <summary>
    /// Called when a Raid event is received
    /// <para>Will fire when not authed as streamer or moderator but will not show data</para>
    /// </summary>
    public event Action<Data>? OnRaidReceived;

    /// <summary>
    /// Called when a Shoutout event is received
    /// </summary>
    public event Action<Data>? OnShoutoutReceived;

    /// <summary>
    /// Called when a ClearChat event is received
    /// </summary>
    public event Action<Data>? OnClearChatReceived;

    /// <summary>
    /// Called when a SystemMessage event is received
    /// </summary>
    public event Action<Data>? OnSystemMessageReceived;

    /// <summary>
    /// Called when an event is received that doesnt fit any event model
    /// </summary>
    public event Action<Data>? OnUnhandledReceived;
    #endregion

    #region Public Methods
    /// <summary>
    /// EventSubClient using SSEClient to connect to chat endpoint (read only)
    /// </summary>
    /// <param name="channelName">Channel to connect with</param>
    /// <param name="botToken">Your bots token</param>
    /// <param name="cookiesJson">A json string of your cookies to load. (Only required in <see cref="ApiClient"/> OR <see cref="EventSubClient"/>)</param>
    public EventSubClient(string channelName, string botToken, string? cookiesJson = null)
    {
        if (string.IsNullOrEmpty(channelName))
        {
            var ex = new ArgumentNullException(nameof(channelName));
            Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
            throw ex;
        }

        ChannelName = channelName;

        if (HttpManager.Singleton is null)
        {
            Assembly? assembly = Assembly.GetCallingAssembly();
            var externalCallerInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            new HttpManager(externalCallerInfo, botToken, cookiesJson);
        }

        if (HttpManager.Singleton is null)
        {
            var ex = new NullReferenceException(nameof(HttpManager.Singleton));
            Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
            throw ex;
        }

        _sseClient = new SseClient("v2/chat/stream", $"channel={channelName}", HttpManager.Singleton.Client, TimeSpan.FromSeconds(45));

        SubscribeSseClientEvents();
    }

    /// <summary>
    /// EventSubClient connect to endpoint as initialized
    /// </summary>
    public async Task ConnectAsync()
    {
        _reconnectionAttempts = 0;
        if (_shutdownCts == null || _shutdownCts.Token.IsCancellationRequested)
            _shutdownCts = new();
        Logger.Singleton?.Log(LogLevel.Info, "Starting SSE connection manager...");
        _connectionTask = MaintainConnectionAsync(_shutdownCts.Token);
        await Task.CompletedTask;
    }

    /// <summary>
    /// EventSubClient disconnect from the endpoint
    /// </summary>
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
    }

    public void Dispose()
    {
        _shutdownCts?.Cancel();
        _sseClient?.Dispose();
        _shutdownCts?.Dispose();
    }
    #endregion

    #region Private Methods
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
            try
            {
                Logger.Singleton?.Log(LogLevel.Info, $"Attempt {_reconnectionAttempts + 1}/{MaxReconnectionAttempts} to connect...");
                await _sseClient!.ConnectAsync(cancellationToken);

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

            if (_reconnectionAttempts >= MaxReconnectionAttempts)
            {
                Logger.Singleton?.Log(LogLevel.Error, $"Max reconnection attempts ({MaxReconnectionAttempts}) reached. Reconnect manually.");
                OnDisconnected?.Invoke();
                _shutdownCts?.Cancel();
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

    private void SubscribeSseClientEvents()
    {
        if (_sseClient is null)
            return;

        _sseClient.OnConnected += () =>
        {
            _reconnectionAttempts = 0;
            OnConnected?.Invoke();
        };

        _sseClient.OnDisconnected += () =>
        {
            OnTimeout?.Invoke();
        };

        _sseClient.OnRawMessageReceived += (string payload) =>
        {
            try
            {
                Data? data = JsonSerializer.Deserialize<Data>(payload)
                    ?? throw new NullReferenceException("Packet data is null");

                var handler = data.Type switch
                {
                    MessageType.Message => OnMessageReceived,
                    MessageType.Reply => OnReplyReceived,
                    MessageType.Delete => OnMessageDeleted,
                    MessageType.Pin => OnMessagePinned,
                    MessageType.Unpin => OnMessageUnPinned,
                    MessageType.Highlight => OnHighlightReceived,
                    MessageType.Redemption => OnRedemptionReceived,
                    //MessageType.Follow => OnFollowReceived,
                    MessageType.Tip => OnTipReceived,
                    MessageType.Subscription => OnSubscriptionReceived,
                    MessageType.Shop => OnShopReceived,
                    //MessageType.RaidStarted => OnRaidStarted,
                    //MessageType.RaidCanceled => OnRaidCanceled,
                    MessageType.RaidReceived => OnRaidReceived,
                    MessageType.Shoutout => OnShoutoutReceived,
                    MessageType.Clear => OnClearChatReceived,
                    MessageType.System => OnSystemMessageReceived,
                    _ => OnUnhandledReceived
                };

                handler?.Invoke(data);
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
    #endregion
}
