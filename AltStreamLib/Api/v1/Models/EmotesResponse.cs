using System.Collections.Generic;
using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
    public class EmotesResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("emotes")]
        public List<EmoteInfo> Emotes { get; set; }

        public EmotesResponse(string channel, List<EmoteInfo> emotes)
        {
            this.Channel = channel;
            this.Emotes = emotes;
        }

        public EmotesResponse() { }
    }
}