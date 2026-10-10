using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record PanelsResponse(
    [property: JsonPropertyName("channel")] string Channel,
    [property: JsonPropertyName("panels")] List<PanelInfo> Panels
);
