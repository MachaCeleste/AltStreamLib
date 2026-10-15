using System.Collections.Generic;
using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
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
}
