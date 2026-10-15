Depends on [SseClientLib](https://github.com/MachaCeleste/SseClientLib)

## Simplified Implementation Example:
```cs
using AltStreamLib.Api;
using AltStreamLib.Api.v1.Models;

public class Program
{
    private static ApiClient _client;

    public static async Task Main()
    {
        _client = new ApiClient();

        Console.WriteLine("AltStream API GET Tester\nby MachaCeleste");
        while (true)
        {
            Console.WriteLine("Enter Command:");
            string? command = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(command))
            {
                string[] parts = command.Split(' ');

                string cmd = parts[0].ToLower();
                string[] args = [..parts.Skip(1)];
                switch (cmd)
                {
                    case "channel":
                        ApiResponse<ChannelResponse>? channelInfo = await _client.GetChannelInfoAsync(args[0]);
                        if (channelInfo == null)
                        {
                            Console.WriteLine($"Could not get info for channel: {args[0]}");
                            return;
                        }

                        var data = channelInfo.Data;

                        Console.WriteLine($"------ Channel Info ------\n" +
                                          $"       Username: {data.Username}\n" +
                                          $"   Display Name: {data.DisplayName}\n" +
                                          $"     Avatar Url: {data.AvatarUrl}\n" +
                                          $"            Bio: {data.Bio}\n" +
                                          $"     Created At: {data.CreatedAt}\n\n" +
                                          $"------ Stream Info ------\n" +
                                          $"        Is Live: {(data.Stream.IsLive ? "ONLINE" : "OFFLINE")}\n" +
                                          $"          Title: {data.Stream.Title}\n" +
                                          $"        Viewers: {data.Stream.Viewers}\n" +
                                          $"     Started At: {data.Stream.StartedAt}\n\n" +
                                          $"------ Game Info ------\n" +
                                          $"        Game Id: {data.Stream.Game.Id}\n," +
                                          $"      Game Name: {data.Stream.Game.Name}\n" +
                                          $"      Game Slug: {data.Stream.Game.Slug}\n" +
                                          $" Game Cover Url: {data.Stream.Game.CoverUrl}");
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {cmd}!");
                        break;
                }
            }
        }
    }
}
```
