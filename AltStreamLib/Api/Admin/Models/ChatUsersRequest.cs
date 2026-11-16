#if NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
#endif
using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Admin.Models
{
#if NET481
    public class ChatUsersRequest
    {
        [JsonProperty("users")]
        public List<ChatUser> Users { get; set; }
    }
#elif NET9_0_OR_GREATER
    public record ChatUsersRequest(
        [property: JsonPropertyName("users")] List<ChatUser> Users
    );
#endif
}
