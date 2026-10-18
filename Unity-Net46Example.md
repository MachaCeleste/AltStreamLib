# Unity Example - Net46 Branch

```cs
using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AltStreamLib;
using AltStreamLib.EventSub;
using AltStreamLib.EventSub.Chat.Models;

public class SSEConnector : MonoBehaviour
{
    private EventSubClient _client;

    private void Awake()
    {
        new AltStreamLib.Logging.Logger();
        AltStreamLib.Logging.Logger.Singleton.OnLog += Singleton_OnLog;

        _client = new EventSubClient("machaceleste");
        _client.OnMessageReceived += _client_OnMessageReceived;
    }

    private void Singleton_OnLog(LogMessage obj)
    {
        Debug.Log($"{obj.Message}");
    }

    async void Start()
    {
        try
        {
            await Task.Run(async () =>
            {
                await _client.ConnectAsync();
            });
        }
        catch (Exception ex)
        {
            Debug.LogError($"SSE Error: {ex.Message}");
        }
    }

    private void _client_OnMessageReceived(Message context)
    {
        Debug.Log($"{DateTimeOffset.FromUnixTimeMilliseconds(context.SentAt)} <{context.Author}> {context.Text}");
    }
}
```
