using System.Collections.Generic;
using Newtonsoft.Json;
using AltStreamLib.Api.v1.Models;

namespace AltStreamLib.Api.Live.Models
{
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
}
