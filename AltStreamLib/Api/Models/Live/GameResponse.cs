#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Live
{
#if NET461 || NET472 || NET481
    public class GameResponse
    {
        [JsonProperty("game")]
        public Game Game { get; set; }

        public GameResponse(Game game)
        {
            this.Game = game;
        }

        public GameResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record GameResponse(
        [property: JsonPropertyName("game")] Game Game
    );
#endif
}
