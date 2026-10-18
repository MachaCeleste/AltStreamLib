using System.Net.Http.Json;
using System.Net.Http.Headers;
using AltStreamLib.Api.v1.Models;
using AltStreamLib.Api.Chat.Models;
using AltStreamLib.Logging;

namespace AltStreamLib.Api
{
    public class ApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new()
            {
                BaseAddress = new Uri("https://altstream.online/api/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ApiResponse<ChannelResponse>?> GetChannelInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<ChannelResponse>>($"v1/channels/{channelName}");

        public async Task<ApiResponse<PanelsResponse>?> GetPanelsInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<PanelsResponse>>($"v1/channels/{channelName}/panels");

        public async Task<ApiResponse<RewardsResponse>?> GetRewardsInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<RewardsResponse>>($"v1/channels/{channelName}/rewards");

        public async Task<ApiResponse<EmotesResponse>?> GetEmotesInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<EmotesResponse>>($"v1/channels/{channelName}/emotes");

        public async Task<ApiResponse<TagsResponse>?> GetTagsInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<TagsResponse>>($"v1/channels/{channelName}/tags");

        public async Task<UserSettingsResponse?> GetUserSettingsInfoAsync(string channelName) =>
            await SendRequestAsync<UserSettingsResponse>($"v1/user-settings/{channelName}");

        public async Task<ModResponse?> GetModInfoAsync(string channelName) =>
            await SendRequestAsync<ModResponse>($"chat/mod?channel={channelName}");

        private async Task<T?> SendRequestAsync<T>(string endpoint)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(endpoint);
            }
            catch (HttpRequestException ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
                return default;
            }
            catch (Exception ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
                throw;
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
