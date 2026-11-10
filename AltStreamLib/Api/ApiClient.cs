using System.Reflection;
using System.Diagnostics;
using AltStreamLib.Api.Models;
using AltStreamLib.Api.v1.Models;
using AltStreamLib.Api.v2.Models;
using AltStreamLib.Api.Chat.Models;
using AltStreamLib.Api.Auth.Models;
using AltStreamLib.Api.Rewards.Models;
using AltStreamLib.Api.Shoutout.Models;
using AltStreamLib.Api.Live.Models;
using AltStreamLib.Api.Admin.Models;
using AltStreamLib.EventSub;
using AltStreamLib.Utils;

namespace AltStreamLib.Api
{
    public class ApiClient : IDisposable
    {
        public SessionResponse? Session { get; private set; }

        private StreamKeyResponse? _streamKey;

        /// <summary>
        /// Initialize new API Client.
        /// <para>Rate limit is 60 Requests/minute.</para>
        /// </summary>
        /// <param name="botToken">Your bots token</param>
        /// <param name="cookiesJson">A json string of your cookies to load. (Only required in <see cref="ApiClient"/> OR <see cref="EventSubClient"/>)</param>
        public ApiClient(string botToken, string? cookiesJson = null)
        {
            if (HttpManager.Singleton is null)
            {
                Assembly? assembly = Assembly.GetCallingAssembly();
                var externalCallerInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                new HttpManager(externalCallerInfo, botToken, cookiesJson);
            }
        }

        #region GET
        /// <summary>
        /// Get <see cref="ChannelResponse"/> for given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="ChannelResponse"/> or null</returns>
        public async Task<ChannelResponse?> GetChannelInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendRequestAsync<ApiResponse<ChannelResponse>>($"v1/channels/{channelName}");
                if (res != null)
                    return res.Data;
            }
            return null;
        }

        /// <summary>
        /// Get <see cref="PanelInfo"/> for a given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="PanelsResponse"/> or null</returns>
        public async Task<PanelsResponse?> GetPanelsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendRequestAsync<ApiResponse<PanelsResponse>>($"v1/channels/{channelName}/panels");
                if (res != null)
                    return res.Data;
            }
            return null;
        }

        /// <summary>
        /// Get <see cref="RewardsResponse"/> for a given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="RewardsResponse"/> or null</returns>
        public async Task<RewardsResponse?> GetRewardsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendRequestAsync<RewardsResponse>($"rewards?channel={channelName}&includeDisabled=true");
                if (res != null)
                    return res;
            }
            return null;
        }

        /// <summary>
        /// Get <see cref="EmotesResponse"/> for a given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="EmotesResponse"/> or null</returns>
        public async Task<EmotesResponse?> GetEmotesInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendRequestAsync<ApiResponse<EmotesResponse>>($"v1/channels/{channelName}/emotes");
                if (res != null)
                    return res.Data;
            }
            return null;
        }

        /// <summary>
        /// Get <see cref="TagsResponse"/> for a given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="TagsResponse"/> or null</returns>
        public  async Task<TagsResponse?> GetTagsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendRequestAsync<ApiResponse<TagsResponse>>($"v1/channels/{channelName}/tags");
                if (res != null)
                    return res.Data;
            }
            return null;
        }

        /// <summary>
        /// Get <see cref="UserSettingsResponse"/> for a given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="UserSettingsResponse"/> or null</returns>
        public async Task<UserSettingsResponse?> GetUserSettingsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<UserSettingsResponse>($"v1/user-settings/{channelName}");
        }

        /// <summary>
        /// Get <see cref="ModResponse"/> for given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="ModResponse"/> or null</returns>
        public async Task<ModResponse?> GetModInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ModResponse>($"chat/mod?channel={channelName}");
        }

        /// <summary>
        /// Get <see cref="ChatUsersRequest"/> for given <paramref name="channelName"/>.
        /// <para>Requires Auth and Moderator permissions</para>
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="ChatUsersRequest"/> or null</returns>
        public async Task<ChatUsersRequest?> GetChatUsersAsync(string channelName)
        {
            if (Session is null || HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ChatUsersRequest>($"admin/chat-users?channel={channelName}");
        }

        /// <summary>
        /// Get the current auth context <see cref="SessionResponse"/> and store it in this <see cref="ApiClient"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        public async Task GetSessionAsync()
        {
            if (HttpManager.Singleton is null) return;
            var temp = await HttpManager.Singleton.SendRequestAsync<SessionResponse>("auth/session");
            if (temp is not null)
                Session = temp;
        }

        /// <summary>
        /// Get the current sessions <see cref="StreamKeyResponse"/> and store it in this <see cref="ApiClient"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        public async Task GetStreamKeyAsync()
        {
            if (HttpManager.Singleton is null) return;
            var temp = await HttpManager.Singleton.SendRequestAsync<StreamKeyResponse>("stream-key");
            if (temp is not null)
                _streamKey = temp;
        }

        /// <summary>
        /// Search for games or catagories by <paramref name="query"/>.
        /// <para>Requires Auth and Stream Key</para>
        /// </summary>
        /// <param name="query">Search Query</param>
        /// <returns>Returns List of <see cref="UpdateGameRequest"/></returns>
        public async Task<List<UpdateGameRequest>?> GetGameSearchAsync(string query)
        {
            if (_streamKey is null || !_streamKey.HasStreamKey || HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<List<UpdateGameRequest>>($"live/game/search?q={query}&key={_streamKey}");
        }
        #endregion

        #region PUT
        /// <summary>
        /// Update an existing reward by <paramref name="rewardId"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <param name="rewardId"></param>
        /// <param name="rewardName"></param>
        /// <param name="rewardDesc"></param>
        /// <param name="rewardCost"></param>
        /// <param name="enabled"></param>
        /// <param name="isHighlight"></param>
        /// <param name="requireUserInput"></param>
        /// <param name="cooldownSeconds"></param>
        /// <param name="globalCooldownSeconds"></param>
        /// <param name="maxPerStream"></param>
        /// <param name="maxGlobalPerStream"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> UpdateRewardAsync(int rewardId, string rewardName, string rewardDesc, int rewardCost, bool enabled, bool isHighlight,
            bool requireUserInput, int? cooldownSeconds = null, int? globalCooldownSeconds = null, int? maxPerStream = null, int? maxGlobalPerStream = null)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var rewardUpdate = new RewardUpdateRequest(rewardId,
                    Session.User.Username, rewardName, rewardDesc, rewardCost, enabled, isHighlight, requireUserInput, cooldownSeconds,
                    globalCooldownSeconds, maxPerStream, maxGlobalPerStream);
                return await HttpManager.Singleton.SendPutRequestAsync<RewardUpdateRequest, RequestResponse>("rewards", rewardUpdate);
            }
            return null;
        }

        /// <summary>
        /// Set the current game.<br/>
        /// Can get game info from <seealso cref="GetGameSearchAsync(string)"/>.
        /// <para>Requires Auth and Stream Key</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="igdbId"></param>
        /// <param name="name"></param>
        /// <param name="slug"></param>
        /// <param name="coverUrl"></param>
        /// <param name="steamId"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> ChangeStreamGameAsync(int id, int igdbId, string name, string slug, string? coverUrl = null, string? steamId = null)
        {
            if (Session is not null && _streamKey is not null && _streamKey.HasStreamKey is true && HttpManager.Singleton is not null)
            {
                var gamePayload = new UpdateGameRequest(
                    id, igdbId, name, slug,
                    coverUrl, steamId, _streamKey.StreamKey,
                    Session.User.Username, null, false, null
                );
                return await HttpManager.Singleton.SendPutRequestAsync<UpdateGameRequest, RequestResponse>("live/game", gamePayload);
            }
            return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Send chat <paramref name="content"/> in streamers channel<br/>
        /// Can reply by setting <paramref name="replyToId"/> to messageId.
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="content"></param>
        /// <param name="replyToId"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> SendChatMessageAsync(string channelName, string content, string? replyToId = null)
        {
            if (HttpManager.Singleton is not null)
            {
                var message = new PostChatRequest(channelName, content, replyToId);
                return await HttpManager.Singleton.SendPostRequestAsync<PostChatRequest, RequestResponse>("v2/chat", message);
            }
            return null;
        }

        /// <summary>
        /// Send a shoutout in given <paramref name="channel"/> for <paramref name="target"/>.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="target"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> SendShoutoutAsync(string channel, string target)
        {
            if (HttpManager.Singleton is not null)
            {
                var shoutout = new ShoutoutRequest(channel, target);
                return await HttpManager.Singleton.SendPostRequestAsync<ShoutoutRequest, RequestResponse>("shoutout", shoutout);
            }
            return null;
        }

        /// <summary>
        /// Create a new reward.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <param name="rewardName"></param>
        /// <param name="rewardCost"></param>
        /// <param name="isHighlight"></param>
        /// <param name="requiresUserInput"></param>
        /// <param name="rewardDesc"></param>
        /// <param name="cooldownSeconds"></param>
        /// <param name="globalCooldownSeconds"></param>
        /// <param name="maxPerStream"></param>
        /// <param name="maxGlobalPerStream"></param>
        /// <returns>False if unsuccessful</returns>
        public async Task<bool> CreateRewardAsync(string rewardName, int rewardCost, bool isHighlight, bool requiresUserInput, string? rewardDesc = null,
            int? cooldownSeconds = null, int? globalCooldownSeconds = null, int? maxPerStream = null, int? maxGlobalPerStream = null)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var rewardPayload = new RewardCreateRequest(Session.User.Username, rewardName, rewardDesc, rewardCost,
                    isHighlight, requiresUserInput, cooldownSeconds, globalCooldownSeconds, maxPerStream, maxGlobalPerStream);
                return await HttpManager.Singleton.SendPostRequestAsync<RewardCreateRequest>("rewards", rewardPayload);
            }
            return false;
        }

        /// <summary>
        /// Change the stream <paramref name="title"/>.
        /// <para>Requires Auth and Stream Key</para>
        /// </summary>
        /// <param name="title"></param>
        /// <returns>False if unsuccessful</returns>
        public async Task<bool> ChangeStreamTitleAsync(string title)
        {
            if (Session is not null && _streamKey is not null && _streamKey.HasStreamKey is true && HttpManager.Singleton is not null)
            {
                var titlePayload = new UpdateTitleRequest(_streamKey.StreamKey, title, Session.User.Username);
                return await HttpManager.Singleton.SendPostRequestAsync<UpdateTitleRequest>("live/title", titlePayload);
            }
            return false;
        }
        #endregion

        #region PATCH
        /// <summary>
        /// Set <paramref name="state"/> of reward by <paramref name="id"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> SetRewardStateAsync(int id, bool state)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var rewardState = new RewardStateRequest(id, Session.User.Username, state);
                return await HttpManager.Singleton.SendPatchRequestAsync<RewardStateRequest, RequestResponse>("rewards", rewardState);
            }
            return null;
        }

        /// <summary>
        /// Reorder rewards using list of <paramref name="orderedIds"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <param name="orderedIds"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> SetRewardOrderAsync(int[] orderedIds)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var rewardOrder = new RewardOrderRequest(Session.User.Username, orderedIds);
                return await HttpManager.Singleton.SendPatchRequestAsync<RewardOrderRequest, RequestResponse>("rewards", rewardOrder);
            }
            return null;
        }

        /// <summary>
        /// Set the fulfillment <paramref name="state"/> of a given <paramref name="redemptionId"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="redemptionId"></param>
        /// <param name="state"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> SetRewardFulfillmentAsync(string channelName, int redemptionId, Fulfillment state)
        {
            if (HttpManager.Singleton is not null)
            {
                var rewardState = new RewardFulfillmentRequest(redemptionId, channelName, state.ToString().ToLower());
                return await HttpManager.Singleton.SendPatchRequestAsync<RewardFulfillmentRequest, RequestResponse>("v2/rewards/redemptions", rewardState);
            }
            return null;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete reward by <paramref name="rewardId"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <param name="rewardId"></param>
        /// <returns>False if unsuccessful</returns>
        public async Task<bool> DeleteRewardAsync(int rewardId)
        {
            if (Session is not null && HttpManager.Singleton is not null)
                return await HttpManager.Singleton.SendDeleteRequestAsync($"rewards?id={rewardId}&username={Session.User.Username}");
            return false;
        }
        #endregion

        #region AUTH
        /// <summary>
        /// Login with <paramref name="account"/> and <paramref name="password"/> to greate a session.<br/>
        /// Can use email or username to login.
        /// <para>Must login before performing any actions that require Auth!</para>
        /// </summary>
        /// <param name="account">Email or Username</param>
        /// <param name="password"></param>
        /// <returns>A json <see cref="string"/> of your cookies. Null if unsuccessful</returns>
        public async Task<string?> AuthenticateAsync(string account, string password)
        {
            if (HttpManager.Singleton is not null)
            {
                var authResponse = await HttpManager.Singleton.SendRequestAsync<AuthResponse>("auth/csrf");
                if (authResponse is not null)
                {
                    var tokenRequest = new AuthTokenRequest(account, password, authResponse.Token);
                    if (await HttpManager.Singleton.SendPostRequestAsync<AuthTokenRequest>("auth/callback/credentials", tokenRequest))
                    {
                        await GetSessionAsync();
                        if (Session is not null)
                            return await HttpManager.Singleton.GetCookieContainerJsonAsync();
                    }
                }
            }
            return null;
        }
        #endregion

        public void Dispose()
        {
            Session = null;
            _streamKey = null;
        }
    }
}
