using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AltStreamLib.Logging;

namespace AltStreamLib.Utils;

internal class HttpManager
{
    internal static HttpManager? Singleton { get; private set; }

    internal HttpClient? Client;
    private CookieContainer _cookieContainer = new CookieContainer();

    internal HttpManager(FileVersionInfo callingInfo, string? cookiesJson = null)
    {
        if (Singleton is not null) return;

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
        var cookieList = JsonConvert.DeserializeObject<List<Cookie>>(json);
        if (cookieList is not null)
            foreach (var cookie in cookieList)
                _cookieContainer.Add(cookie);
    }

    internal async Task<string> GetCookieContainerJsonAsync()
    {
        CookieCollection cookies = _cookieContainer.GetCookies(Client.BaseAddress);

        var cookieList = new List<Cookie>();
        foreach (Cookie cookie in cookies)
            cookieList.Add(cookie);
        string json = JsonConvert.SerializeObject(cookieList);

        return json;
    }

    internal async Task<T?> SendRequestAsync<T>(string endpoint)
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

    internal async Task<TResponse?> SendPutRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
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

    internal async Task<TResponse?> SendPostRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
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

    internal async Task<TResponse?> SendPatchRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
    {
        try
        {
            var json = JsonConvert.SerializeObject(payload);
            using var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(Client.BaseAddress, endpoint),
                Content = content
            };

            using var response = await Client.SendAsync(request);
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
