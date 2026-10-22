using System;
using System.Net.Http;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SseClientLib;
using AltStreamLib.EventSub.Chat;
using AltStreamLib.EventSub.Chat.Models;
using AltStreamLib.EventSub.Chat.Models.Events;
using AltStreamLib.Logging;

namespace AltStreamLib.EventSub
{
    public class EventSubClient : IDisposable
    {
        public string ChannelName { get; private set; }

        private const string _chatEndpoint = "https://altstream.online/api/chat/stream";
        private readonly string _channel;

        private FileVersionInfo _libraryInfo;
        private FileVersionInfo _externalCallerInfo;

        private SseClient _sseClient;
        private Task _connectionTask;
        private CancellationTokenSource _shutdownCts;

        private int _reconnectionAttempts;
        private const int MaxReconnectionAttempts = 5;
        private readonly TimeSpan _baseReconnectDelay = TimeSpan.FromSeconds(60);

        #region Events
        /// <summary>
        /// Called on SSE Client Connected
        /// </summary>
        public event Action OnConnected;

        /// <summary>
        /// Called when SSE Client is in timeout but attempting reconnect
        /// </summary>
        public event Action OnTimeout;

        /// <summary>
        /// Called when SSE Client has stood down and cancels the CTS token
        /// </summary>
        public event Action OnDisconnected;

        /// <summary>
        /// Called when a Message is received
        /// </summary>
        public event Action<Message> OnMessageReceived;

        /// <summary>
        /// Called when a MessageDeleted event is received
        /// </summary>
        public event Action<EventMessage> OnMessageDeleted;

        /// <summary>
        /// Called when a MessagePinned event is received
        /// </summary>
        public event Action<EventMessage> OnMessagePinned;

        /// <summary>
        /// Called when a MessageUnpinned event is received
        /// </summary>
        public event Action<EventMessage> OnMessageUnPinned;

        /// <summary>
        /// Called when a HighlightMessage event is received
        /// </summary>
        public event Action<EventMessage> OnHighlightReceived;

        /// <summary>
        /// Called when a Redemption event is received
        /// </summary>
        public event Action<EventMessage> OnRedemptionReceived;

        /// <summary>
        /// Called when a Follow event is received
        /// </summary>
        [Obsolete("OnFollowReseived is preserved as a possible future function but may not currently be used!")]
        public event Action<EventMessage> OnFollowReceived;

        /// <summary>
        /// Called when a KoFiTip event is received
        /// </summary>
        [Obsolete("OnTipReceived is preserved as a possible future function but may not currently be used!")]
        public event Action<EventMessage> OnTipReceived;

        /// <summary>
        /// Called when a KoFiSubscription event is received
        /// </summary>
        [Obsolete("OnSubscriptionReceived is preserved as a possible future function but may not currently be used!")]
        public event Action<EventMessage> OnSubscriptionReceived;

        /// <summary>
        /// Called when a KoFiShop event is received
        /// </summary>
        [Obsolete("OnShopReceived is preserved as a possible future function but may not currently be used!")]
        public event Action<EventMessage> OnShopReceived;

        /// <summary>
        /// Called when a RaidStart event is received
        /// </summary>
        public event Action<EventMessage> OnRaidStarted;

        /// <summary>
        /// Called when a RaidCanceled event is received
        /// </summary>
        public event Action<EventMessage> OnRaidCanceled;

        /// <summary>
        /// Called when a Raid event is received
        /// </summary>
        public event Action<EventMessage> OnRaidReceived;

        /// <summary>
        /// Called when a Shoutout event is received
        /// </summary>
        public event Action<EventMessage> OnShoutoutReceived;

        /// <summary>
        /// Called when a ClearChat event is received
        /// </summary>
        public event Action<EventMessage> OnClearChatReceived;

        /// <summary>
        /// Called when a SystemMessage event is received
        /// </summary>
        public event Action<EventMessage> OnSystemMessageReceived;

        /// <summary>
        /// Called when an event is received that doesnt fit any event model
        /// </summary>
        public event Action<EventMessage> OnUnhandledReceived;
        #endregion

        #region Public Methods
        /// <summary>
        /// EventSubClient using SSEClient to connect to chat endpoint (read only)
        /// </summary>
        /// <param name="channelName">Channel to connect with</param>
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

            Assembly? libAssembly = Assembly.GetExecutingAssembly();
            _libraryInfo = FileVersionInfo.GetVersionInfo(libAssembly.Location);

            Assembly assembly = Assembly.GetCallingAssembly();
            _externalCallerInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            _sseClient = new SseClient(_chatEndpoint, _channel, TimeSpan.FromSeconds(45));

            SubscribeSseClientEvents();
        }

        /// <summary>
        /// EventSubClient connect to endpoint as initialized
        /// </summary>
        public async Task ConnectAsync()
        {
            _reconnectionAttempts = 0;
            if (_shutdownCts == null || _shutdownCts.Token.IsCancellationRequested)
                _shutdownCts = new CancellationTokenSource();
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

            if (_connectionTask != null)
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
                    await _sseClient.ConnectAsync(_libraryInfo, _externalCallerInfo, cancellationToken);

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

                TimeSpan delay = TimeSpan.FromTicks((long)(_baseReconnectDelay.Ticks
                    * Math.Pow(2, _reconnectionAttempts - 1)))
                    + TimeSpan.FromTicks(new Random().Next(0, 1000) * 10);

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
                        Action<EventMessage> handler;

                        switch (eventMsg.EventType)
                        {
                            case EventType.DeleteMessage:
                                handler = OnMessageDeleted;
                                break;
                            case EventType.Pin:
                                handler = OnMessagePinned;
                                break;
                            case EventType.Unpin:
                                handler = OnMessageUnPinned;
                                break;
                            case EventType.Highlight:
                                handler = OnHighlightReceived;
                                break;
                            case EventType.Redeem:
                                handler = OnRedemptionReceived;
                                break;
                            case EventType.Follow:
                                handler = OnFollowReceived;
                                break;
                            case EventType.Tip:
                                handler = OnTipReceived;
                                break;
                            case EventType.Subscription:
                                handler = OnSubscriptionReceived;
                                break;
                            case EventType.Shop:
                                handler = OnShopReceived;
                                break;
                            case EventType.RaidStart:
                                handler = OnRaidStarted;
                                break;
                            case EventType.RaidCancel:
                                handler = OnRaidCanceled;
                                break;
                            case EventType.RaidReceived:
                                handler = OnRaidReceived;
                                break;
                            case EventType.Shoutout:
                                handler = OnShoutoutReceived;
                                break;
                            case EventType.ClearChat:
                                handler = OnClearChatReceived;
                                break;
                            case EventType.SystemMessage:
                                handler = OnSystemMessageReceived;
                                break;
                            default:
                                handler = OnUnhandledReceived;
                                break;
                        }

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
        #endregion
    }
}
