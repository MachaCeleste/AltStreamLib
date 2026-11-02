using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using AltStreamLib.Api.Auth.Models;
using AltStreamLib.Api.Chat.Models;
using AltStreamLib.Api.Rewards.Models;
using AltStreamLib.Api.Shoutout.Models;
using AltStreamLib.Api.v1.Models;
using AltStreamLib.Utils;

namespace AltStreamLib.Api
{
    public class ApiClient : IDisposable
    {
        public SessionResponse Session { get; private set; }

        /// <summary>
        /// Initialize new API Client (Rate limit is 60 Requests/minute)
        /// </summary>
        /// <param name="cookiesJson">A json string of your cookies to load. (Only required once per )</param>
        public ApiClient(string cookiesJson = null)
        {
            if (HttpManager.Singleton is null)
            {
                Assembly assembly = Assembly.GetCallingAssembly();
                var externalCallerInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                new HttpManager(externalCallerInfo, cookiesJson);
            }
        }

        #region GET
        public async Task<ApiResponse<ChannelResponse>> GetChannelInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ApiResponse<ChannelResponse>>($"v1/channels/{channelName}");
        }

        public async Task<ApiResponse<PanelsResponse>> GetPanelsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ApiResponse<PanelsResponse>>($"v1/channels/{channelName}/panels");
        }

        public async Task<ApiResponse<RewardsResponse>> GetRewardsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ApiResponse<RewardsResponse>>($"v1/channels/{channelName}/rewards");
        }

        public async Task<ApiResponse<EmotesResponse>> GetEmotesInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ApiResponse<EmotesResponse>>($"v1/channels/{channelName}/emotes");
        }

        public async Task<ApiResponse<TagsResponse>> GetTagsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ApiResponse<TagsResponse>>($"v1/channels/{channelName}/tags");
        }

        public async Task<UserSettingsResponse> GetUserSettingsInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<UserSettingsResponse>($"v1/user-settings/{channelName}");
        }


        /// <summary>
        /// UNDOCUMENTED - Requests moderators for given channel
        /// </summary>
        /// <param name="channelName">The channel to query</param>
        public async Task<ModResponse> GetModInfoAsync(string channelName)
        {
            if (HttpManager.Singleton is null) return null;
            return await HttpManager.Singleton.SendRequestAsync<ModResponse>($"chat/mod?channel={channelName}");
        }
        #endregion

        #region PUT
        /// <summary>
        /// Update an existing reward of <paramref name="rewardId"/>
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
        /// <returns>Null if unsuccessful</returns>
        public async Task<RequestResponse> UpdateRewardAsync(int rewardId, string rewardName, string rewardDesc, int rewardCost, bool enabled, bool isHighlight,
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
        #endregion

        #region POST
        /// <summary>
        /// Send a chat message with <paramref name="content"/>
        /// Can reply using <paramref name="replyToId"/> to point to a message
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="content"></param>
        /// <param name="replyToId"></param>
        /// <param name="replyToAuthor"></param>
        /// <returns>Null if unsuccessful</returns>
        public async Task<RequestResponse> SendChatMessageAsync(string channel, string content, string? replyToId = null, string? replyToAuthor = null)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                Random rng = new Random(Guid.NewGuid().GetHashCode());
                var message = new ChatMessagePostRequest(rng.Next(100000, int.MaxValue).ToString(),
                    channel, Session.User.Name, $"[🤖] {content}", replyToId, replyToAuthor);
                return await HttpManager.Singleton.SendPostRequestAsync<ChatMessagePostRequest, RequestResponse>("chat", message);
            }
            return null;
        }

        public async Task<RequestResponse> SendShoutoutAsync(string channel, string target)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var shoutout = new ShoutoutRequest(channel, target);
                return await HttpManager.Singleton.SendPostRequestAsync<ShoutoutRequest, RequestResponse>("shoutout", shoutout);
            }
            return null;
        }

        /// <summary>
        /// Create a new reward
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
        #endregion

        #region PATCH
        /// <summary>
        /// Enable or Disable a reward given an <paramref name="id"/> and <paramref name="state"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns>Null if unsuccessful</returns>
        public async Task<RequestResponse> SetRewardStateAsync(int id, bool state)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var rewardState = new RewardStateRequest(id, Session.User.Username, state);
                return await HttpManager.Singleton.SendPatchRequestAsync<RewardStateRequest, RequestResponse>("rewards", rewardState);
            }
            return null;
        }

        /// <summary>
        /// Reorder rewards given a list of <paramref name="orderedIds"/>
        /// </summary>
        /// <param name="orderedIds"></param>
        /// <returns>Null if unsuccessful</returns>
        public async Task<RequestResponse> SetRewardOrderAsync(int[] orderedIds)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var rewardOrder = new RewardOrderRequest(Session.User.Username, orderedIds);
                return await HttpManager.Singleton.SendPatchRequestAsync<RewardOrderRequest, RequestResponse>("rewards", rewardOrder);
            }
            return null;
        }

        /// <summary>
        /// Set the fulfillment <paramref name="state"/> of a given redemption given a <paramref name="redemptionId"/>
        /// </summary>
        /// <param name="redemptionId"></param>
        /// <param name="state"></param>
        /// <returns>Null if unsuccessful</returns>
        public async Task<RequestResponse> SetRewardFulfillmentAsync(int redemptionId, Fulfillment state)
        {
            if (Session is not null && HttpManager.Singleton is not null)
            {
                var rewardState = new RewardFulfillmentRequest(redemptionId, Session.User.Username, state.ToString().ToLower());
                return await HttpManager.Singleton.SendPatchRequestAsync<RewardFulfillmentRequest, RequestResponse>("rewards/redemptions", rewardState);
            }
            return null;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete a reward from your channel given a <paramref name="rewardId"/>
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
        /// Login with <paramref name="account"/> and <paramref name="password"/> to greate a session
        /// Must login before performing any actions that require Auth
        /// </summary>
        /// <param name="account">Email or Username</param>
        /// <param name="password"></param>
        /// <returns>A json string of your cookies. Null if unsuccessful</returns>
        public async Task<string> AuthenticateAsync(string account, string password)
        {
            if (Session is null && HttpManager.Singleton is not null)
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

        public async Task GetSessionAsync()
        {
            if (HttpManager.Singleton is null) return; // Should maybe handle this
            var temp = await HttpManager.Singleton.SendRequestAsync<SessionResponse>("auth/session");
            if (temp is not null)
                Session = temp;
        }
        #endregion

        public void Dispose()
        {
            Session = null;
        }
    }
}
