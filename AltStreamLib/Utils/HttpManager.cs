using System.Net;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Diagnostics;
using AltStreamLib.Logging;
using System.Text.Json.Serialization;

#if NET461 || NET472 || NET481
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
#elif NET9_0_OR_GREATER
using System.Text.Json;
#endif

namespace AltStreamLib.Utils
{
    internal class HttpManager
    {
        internal static HttpManager? Singleton { get; private set; }

        internal HttpClient? Client;
        private CookieContainer _cookieContainer = new CookieContainer();

        internal HttpManager(FileVersionInfo callingInfo, string botToken, string? cookiesJson = null)
        {
            if (Singleton is not null || string.IsNullOrWhiteSpace(botToken)) return;

            if (!string.IsNullOrEmpty(cookiesJson))
                LoadCookieContainerAsync(cookiesJson);

            var handler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer,
                UseCookies = true
            };
            Client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://altstream.online/api/")
            };

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", botToken);

            Assembly? libAssembly = Assembly.GetExecutingAssembly();
            var libraryInfo = FileVersionInfo.GetVersionInfo(libAssembly.Location);
            Client.DefaultRequestHeaders.Add("AltStreamLib", $"{libraryInfo.ProductName}v{libraryInfo.ProductVersion}");

            if (callingInfo != null)
                Client.DefaultRequestHeaders.Add("CallingAssembly", $"{callingInfo.ProductName}v{callingInfo.ProductVersion}");

            Assembly? entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                FileVersionInfo? entryInfo = FileVersionInfo.GetVersionInfo(entryAssembly.Location);
                if (entryInfo != null)
                    Client.DefaultRequestHeaders.Add("EntryAssembly", $"{entryInfo.ProductName}v{entryInfo.ProductVersion}");
            }

            Singleton = this;
        }

        internal void LoadCookieContainerAsync(string json)
        {
#if NET461 || NET472 || NET481
        var cookieList = JsonConvert.DeserializeObject<List<Cookie>>(json);
#elif NET9_0_OR_GREATER
            var cookieList = JsonSerializer.Deserialize<List<Cookie>>(json);
#endif
            if (cookieList is not null)
                foreach (var cookie in cookieList)
                    _cookieContainer.Add(cookie);
        }

        internal async Task<string> GetCookieContainerJsonAsync()
        {
#if NET461 || NET472 || NET481
        CookieCollection cookies = _cookieContainer.GetCookies(Client.BaseAddress);
#elif NET9_0_OR_GREATER
            CookieCollection cookies = _cookieContainer.GetAllCookies();
#endif

            var cookieList = new List<Cookie>();
            foreach (Cookie cookie in cookies)
                cookieList.Add(cookie);
#if NET461 || NET472 || NET481
        string json = JsonConvert.SerializeObject(cookieList);
#elif NET9_0_OR_GREATER
            string json = JsonSerializer.Serialize(cookieList, new JsonSerializerOptions { WriteIndented = true });
#endif

            return json;
        }


#if NET461 || NET472 || NET481
    internal async Task<T> SendRequestAsync<T>(string endpoint)
#elif NET9_0_OR_GREATER
        internal async Task<T?> SendRequestAsync<T>(string endpoint)
#endif
        {
            try
            {
                return await Client.GetFromJsonAsync<T>(endpoint);
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

#if NET461 || NET472 || NET481
    internal async Task<TResponse> SendPutRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
#elif NET9_0_OR_GREATER
        internal async Task<TResponse?> SendPutRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
#endif
        {
            try
            {
                using var response = await Client.PutAsJsonAsync(endpoint, payload);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<TResponse>();
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

        internal async Task<bool> SendPostRequestAsync<TRequest>(string endpoint, TRequest payload)
        {
            try
            {
                using var response = await Client.PostAsJsonAsync(endpoint, payload);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
                throw;
            }
        }

#if NET461 || NET472 || NET481
    internal async Task<TResponse> SendPostRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
#elif NET9_0_OR_GREATER
        internal async Task<TResponse?> SendPostRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
#endif
        {
            try
            {
                using var response = await Client.PostAsJsonAsync(endpoint, payload);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<TResponse>();
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

#if NET461 || NET472 || NET481
    internal async Task<TResponse> SendPatchRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
#elif NET9_0_OR_GREATER
        internal async Task<TResponse?> SendPatchRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
#endif
        {
            try
            {
#if NET461 || NET472 || NET481
            var json = JsonConvert.SerializeObject(payload);
#elif NET9_0_OR_GREATER
                var json = JsonSerializer.Serialize(payload);
#endif
                using var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

#if NET461 || NET472 || NET481
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(Client.BaseAddress, endpoint),
                Content = content
            };

            using var response = await Client.SendAsync(request);
#elif NET9_0_OR_GREATER
                using var response = await Client.PatchAsync(endpoint, content);
#endif
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<TResponse>();
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

        internal async Task<bool> SendDeleteRequestAsync(string endpoint)
        {
            try
            {
                using var response = await Client.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Singleton?.Log(LogLevel.Error, ex.Message, ex);
                throw;
            }
        }
    }
}
