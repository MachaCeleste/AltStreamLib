using System.Collections.Generic;
using Newtonsoft.Json;

namespace AltStreamLib.Api.Admin.Models
{
    public class ChatUsersRequest
    {
        [JsonProperty("users")]
        public List<ChatUser> Users { get; set; }
    }
}
