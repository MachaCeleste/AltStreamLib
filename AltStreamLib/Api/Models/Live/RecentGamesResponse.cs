#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Live
{
#if NET461 || NET472 || NET481
    public class RecentGamesResponse
    {
        [JsonProperty("games")]
        public List<Game> Games { get; set; }

        public RecentGamesResponse(List<Game> games)
        {
            this.Games = games;
        }

        public RecentGamesResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record RecentGamesResponse(
        [property: JsonPropertyName("games")] List<Game> Games
    );
#endif
}
