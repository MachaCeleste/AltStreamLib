#if NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.v1.Models
{
#if NET481
    public class PanelsResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("panels")]
        public List<PanelInfo> Panels { get; set; }

        public PanelsResponse(string channel, List<PanelInfo> panels)
        {
            this.Channel = channel;
            this.Panels = panels;
        }

        public PanelsResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record PanelsResponse(
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("panels")] List<PanelInfo> Panels
    );
#endif
}
