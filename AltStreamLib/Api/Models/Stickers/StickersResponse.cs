#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Stickers
{
#if NET461 || NET472 || NET481
    public class StickersResponse
    {
        [JsonProperty("stickers")]
        public List<Sticker> Stickers { get; set; }

        public StickersResponse(List<Sticker> stickers)
        {
            this.Stickers = stickers;
        }

        public StickersResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record StickersResponse(
        [property: JsonPropertyName("stickers")] List<Sticker> Stickers
    );
#endif
}
