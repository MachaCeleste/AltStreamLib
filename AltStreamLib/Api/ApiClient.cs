using System.Net.Http.Headers;
using System.Net.Http.Json;
using AltStreamLib.Api.v1.Models;

namespace AltStreamLib.Api
{
    public class ApiClient : IDisposable
    {
        public event Action<Exception> OnError;

        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new()
            {
                BaseAddress = new Uri("https://altstream.online/api/v1/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ApiResponse<ChannelResponse>?> GetChannelInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<ChannelResponse>>($"channels/{channelName}");

        public async Task<ApiResponse<PanelsResponse>?> GetPanelsInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<PanelsResponse>>($"channels/{channelName}/panels");

        public async Task<ApiResponse<RewardsResponse>?> GetRewardsInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<RewardsResponse>>($"channels/{channelName}/rewards");

        public async Task<ApiResponse<EmotesResponse>?> GetEmotesInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<EmotesResponse>>($"channels/{channelName}/emotes");

        public async Task<ApiResponse<UserSettingsResponse>?> GetUserSettingsInfoAsync(string channelName) =>
            await SendRequestAsync<ApiResponse<UserSettingsResponse>?>($"user-settings/{channelName}");

        private async Task<T?> SendRequestAsync<T>(string endpoint)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(endpoint);
            }
            catch (HttpRequestException ex)
            {
                return default;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
                throw;
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
