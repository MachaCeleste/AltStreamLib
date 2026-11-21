#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

using AltStreamLib.Api.Models.v1;

namespace AltStreamLib.Api.Models.Live
{
#if NET461 || NET472 || NET481
    public class UpdatePanelsRequest
    {

        [JsonProperty("panels")]
        public List<PanelInfo> Panels { get; set; }

        public UpdatePanelsRequest(List<PanelInfo> panels)
        {
            Panels = panels;
        }

        public UpdatePanelsRequest() { }
    }
#elif NET9_0_OR_GREATER
    public record UpdatePanelsRequest(
        [property: JsonPropertyName("panels")] List<PanelInfo> Panels
    );
#endif
}
