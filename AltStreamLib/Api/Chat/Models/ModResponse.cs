using System.Collections.Generic;
using Newtonsoft.Json;

namespace AltStreamLib.Api.Chat.Models
{
    public class ModResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("moderators")]
        public List<Moderator> Moderators { get; set; }

        public ModResponse(bool success, List<Moderator> moderators)
        {
            this.Success = success;
            this.Moderators = moderators;
        }
    }
}
