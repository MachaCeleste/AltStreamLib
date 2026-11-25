#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.Live
{
#if NET461 || NET472 || NET481
    public class TitleResponse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        public TitleResponse(string title)
        {
            this.Title = title;
        }

        public TitleResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record TitleResponse(
        [property: JsonPropertyName("title")] string Title
    );
#endif
}
