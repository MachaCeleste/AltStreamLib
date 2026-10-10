using System.Text.Json.Serialization;

namespace AltStreamLib.Api.v1.Models;

public record ApiResponse<T>(
    [property: JsonPropertyName("data")] T Data
);
