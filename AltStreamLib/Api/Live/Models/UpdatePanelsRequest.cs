using System.Text.Json.Serialization;
using AltStreamLib.Api.v1.Models;

namespace AltStreamLib.Api.Live.Models;

public record UpdatePanelsRequest(
    [property: JsonPropertyName("panels")] List<PanelInfo> Panels
);
