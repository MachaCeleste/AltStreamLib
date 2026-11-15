using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v2.Models;

public record RedemptionsResponse(
    [property: JsonPropertyName("redemptions")] List<Redemption> Redemptions
);
