#if NET461 || NET472 || NET481
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endif

using System.Reflection;
using System.Diagnostics;
using AltStreamLib.Api.Models;
using AltStreamLib.Api.Models.v1;
using AltStreamLib.Api.Models.v2;
using AltStreamLib.Api.Models.Activity;
using AltStreamLib.Api.Models.Admin;
using AltStreamLib.Api.Models.Auth;
using AltStreamLib.Api.Models.Chat;
using AltStreamLib.Api.Models.Live;
using AltStreamLib.Api.Models.Rewards;
using AltStreamLib.Api.Models.Shoutout;
using AltStreamLib.Api.Models.Stickers;
using AltStreamLib.Api.Models.User_Settings;
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
        /// <para>Please rate limit to 60 Requests/minute.</para>
        /// </summary>
        /// <param name="botToken">Your bots token</param>
        /// <param name="cookiesJson">A json string of your cookies to load. (Only required in <see cref="ApiClient"/> OR <see cref="EventSubClient"/>)</param>
        public ApiClient(string botToken, string cookiesJson = null)
        {
            if (HttpManager.Singleton is null)
            {
                Assembly assembly = Assembly.GetCallingAssembly();
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
        public async Task<ChannelResponse> GetChannelInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendGetRequestAsync<ApiResponse<ChannelResponse>>($"v1/channels/{channelName}");
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
        public async Task<PanelsResponse> GetPanelsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendGetRequestAsync<ApiResponse<PanelsResponse>>($"v1/channels/{channelName}/panels");
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
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<RewardsResponse>($"rewards?channel={channelName}&includeDisabled=true");
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
                var res = await HttpManager.Singleton.SendGetRequestAsync<ApiResponse<EmotesResponse>>($"v1/channels/{channelName}/emotes");
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
                var res = await HttpManager.Singleton.SendGetRequestAsync<ApiResponse<TagsResponse>>($"v1/channels/{channelName}/tags");
                if (res != null)
                    return res.Data;
            }
            return null;
        }

        /// <summary>
        /// Get <see cref="UserSettingsResponse"/> for a given <paramref name="channelName"/>.<br/>
        /// Optional: <paramref name="relativeChannel"/> can be used to get relative info
        /// </summary>
        /// <param name="channelName">Info to get</param>
        /// <param name="relativeChannel">Channel to get info relative to</param>
        /// <returns><see cref="UserSettingsResponse"/> or null</returns>
        public async Task<UserSettingsResponse?> GetUserSettingsInfoAsync(string channelName, string relativeChannel = "")
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<UserSettingsResponse>(
                $"v1/user-settings/{channelName}{(string.IsNullOrEmpty(relativeChannel) ? "" : $"?channel={relativeChannel}")}");
        }

        /// <summary>
        /// Get all stickers available on the site.
        /// </summary>
        /// <returns><see cref="StickersResponse"/> or null</returns>
        public async Task<StickersResponse?> GetStickersAsync()
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<StickersResponse>("stickers");
        }

        /// <summary>
        /// Get the current title for given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="string"/> or null</returns>
        public async Task<string?> GetCurrentTitleAsync(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendGetRequestAsync<TitleResponse>($"live/title?channel={channelName}");
                if (res != null)
                    return res.Title;
            }
            return null;
        }

        /// <summary>
        /// Get the current live <see cref="Game"/> for given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="Game"/> or null</returns>
        public async Task<Game?> GetCurrentGame(string channelName)
        {
            if (HttpManager.Singleton is not null)
            {
                var res = await HttpManager.Singleton.SendGetRequestAsync<GameResponse>($"live/game?channel={channelName}");
                if (res != null)
                    return res.Game;
            }
            return null;
        }

        /// <summary>
        /// Get list of recent <see cref="Game"/> for given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="limit">Optional limit to results</param>
        /// <returns>List of <see cref="Game"/> or null</returns>
        public async Task<List<Game>?> GetRecentGamesAsync(string channelName, int limit = -1)
        {
            if (HttpManager.Singleton is not null)
            {
                string limitRes = limit > -1 ? $"&limit={limit}" : string.Empty;
                var res = await HttpManager.Singleton.SendGetRequestAsync<RecentGamesResponse>($"live/game/recent?channel={channelName}{limitRes}");
                if (res != null)
                    return res.Games;
            }
            return null;
        }

        /// <summary>
        /// Get <see cref="AchievementsResponse"/> for a given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="AchievementsResponse"/> or null</returns>
        public async Task<AchievementsResponse?> GetAchievementsAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<AchievementsResponse>($"v1/achievements/{channelName}");
        }

        /// <summary>
        /// Get <see cref="User"/> info for given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="User"/> or null</returns>
        public async Task<User?> GetUserInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<User>($"v2/users/{channelName}");
        }

        /// <summary>
        /// Get a list of <see cref="Redemption"/>s for a given <paramref name="channelName"/>.<br/>
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="status">Optional filter by <see cref="RedemptionStatus"/></param>
        /// <param name="limit">Optional limit to results</param>
        /// <returns>List of <see cref="Redemption"/> or null</returns>
        public async Task<RedemptionsResponse?> GetRedemptionsAsync(string channelName, RedemptionStatus status = RedemptionStatus.None, int limit = -1)
        {
            if (HttpManager.Singleton is null) return null;
            string statusRes = status is not RedemptionStatus.None ? $"&status={status.ToString().ToLower()}" : string.Empty;
            string limitRes = limit > -1 ? $"&limit={limit}" : string.Empty;
            return await HttpManager.Singleton.SendGetRequestAsync<RedemptionsResponse>($"v2/rewards/redemptions?channel={channelName}{limitRes}");
        }

        /// <summary>
        /// Get <see cref="ModResponse"/> for given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns><see cref="ModResponse"/> or null</returns>
        public async Task<ModResponse?> GetModInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<ModResponse>($"chat/mod?channel={channelName}");
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
            return await HttpManager.Singleton.SendGetRequestAsync<ChatUsersRequest>($"admin/chat-users?channel={channelName}");
        }

        /// <summary>
        /// Get <see cref="ActivityResponse"/> containing activity event history info.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <param name="limit">Optional limit to results</param>
        /// <returns><see cref="ActivityResponse"/> or null</returns>
        public async Task<ActivityResponse?> GetActivityAsync(int limit = -1)
        {
            if (Session is null || HttpManager.Singleton is null) return null;
            string limitRes = limit > -1 ? $"&limit={limit}" : string.Empty;
            return await HttpManager.Singleton.SendGetRequestAsync<ActivityResponse>($"activity?channel={Session.User.Username}{limitRes}");
        }

        /// <summary>
        /// Gets a <see cref="SubscribersResponse"/> containing subscription history info.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <returns><see cref="SubscribersResponse"/> or null</returns>
        public async Task<SubscribersResponse?> GetSubscribersAsync()
        {
            if (Session is null || HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<SubscribersResponse>($"user-settings/kofi-subscribers?channel={Session.User.Username}");
        }

        /// <summary>
        /// Get the current auth context <see cref="SessionResponse"/> and store it in this <see cref="ApiClient"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        public async Task GetSessionAsync()
        {
            if (HttpManager.Singleton is null) return;
            var temp = await HttpManager.Singleton.SendGetRequestAsync<SessionResponse>("auth/session");
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
            var temp = await HttpManager.Singleton.SendGetRequestAsync<StreamKeyResponse>("stream-key");
            if (temp is not null)
                _streamKey = temp;
        }

        /// <summary>
        /// Search for games or catagories by <paramref name="query"/>.
        /// <para>Requires Auth and Stream Key</para>
        /// </summary>
        /// <param name="query">Search Query</param>
        /// <returns>Returns List of <see cref="Game"/></returns>
        public async Task<List<Game>?> GetGameSearchAsync(string query)
        {
            if (_streamKey is null || !_streamKey.HasStreamKey || HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendGetRequestAsync<List<Game>>($"live/game/search?q={query}&key={_streamKey}");
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
        /// <param name="igdbId"></param>
        /// <param name="adult"></param>
        /// <param name="ai"></param>
        /// <param name="aiDetails"></param>
        /// <param name="aiTools"></param>
        /// <param name="aiToolDetail"></param>
        /// <returns><see cref="RequestResponse"/> or null</returns>
        public async Task<RequestResponse?> ChangeStreamGameAsync(
            int igdbId, bool adult = false, bool ai = false, string? aiDetails = null, bool aiTools = false, string? aiToolDetail = null)
        {
            if (Session is not null && _streamKey is not null && _streamKey.HasStreamKey is true && HttpManager.Singleton is not null)
            {
                var gamePayload = new UpdateGameRequest(
                    Session.User.Id, igdbId, adult, ai, aiDetails, aiTools, aiToolDetail, Session.User.Username, _streamKey.StreamKey);
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
        public async Task<RequestResponse?> SendChatMessageAsync(string channelName, string content, string replyToId = null)
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
        public async Task<bool> CreateRewardAsync(string rewardName, int rewardCost, bool isHighlight, bool requiresUserInput, string rewardDesc = null,
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

        /// <summary>
        /// Delete message by <paramref name="messageId"/>.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns>False if unsuccessful</returns>
        public async Task<bool> DeleteMessageAsync(string messageId)
        {
            if (Session is not null && HttpManager.Singleton is not null)
                return await HttpManager.Singleton.SendDeleteRequestAsync($"chat?channel={Session.User.Username}&id={messageId}");
            return false;
        }

        /// <summary>
        /// Reset stream game to Just Chatting.
        /// <para>Requires Auth</para>
        /// </summary>
        /// <returns>False if unsuccessful</returns>
        public async Task<bool> DeleteStreamGameAsync()
        {
            if (Session is not null && HttpManager.Singleton is not null)
                return await HttpManager.Singleton.SendDeleteRequestAsync("live/game");
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
                var authResponse = await HttpManager.Singleton.SendGetRequestAsync<AuthResponse>("auth/csrf");
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
