using System.Text.Json.Serialization;

namespace AltStreamLib.Api.Admin.Models;

public record ChatUsersRequest(
    [property: JsonPropertyName("users")] List<ChatUser> Users
);
