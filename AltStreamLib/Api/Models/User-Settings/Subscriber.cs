#if NET461 || NET472 || NET481
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.User_Settings
{
#if NET461 || NET472 || NET481
    public class Subscriber
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("userDisplayName")]
        public string UserDisplayName { get; set; }

        [JsonProperty("userImage")]
        public string UserImage { get; set; }

        [JsonProperty("userNumber")]
        public int? UserNumber { get; set; }

        [JsonProperty("fromName")]
        public string FromName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("tierName")]
        public string TierName { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("isFirstSubscriptionPayment")]
        public bool IsFirstSubscriptionPayment { get; set; }

        [JsonProperty("subscriberUntil")]
        public string SubscriberUntil { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        public Subscriber(int id, string channel, string userId, string username, string userDisplayName,
            string userImage, int userNumber, string fromName, string email, string tierName, string amount,
            string currency, string message, string eventType, bool isFirstSubscriptionPayment, string subscriberUntil,
            string createdAt, string provider, bool isActive)
        {
            this.Id = id;
            this.Channel = channel;
            this.UserId = userId;
            this.Username = username;
            this.UserDisplayName = userDisplayName;
            this.UserImage = userImage;
            this.UserNumber = userNumber;
            this.FromName = fromName;
            this.Email = email;
            this.TierName = tierName;
            this.Amount = amount;
            this.Currency = currency;
            this.Message = message;
            this.EventType = eventType;
            this.IsFirstSubscriptionPayment = isFirstSubscriptionPayment;
            this.SubscriberUntil = subscriberUntil;
            this.CreatedAt = createdAt;
            this.Provider = provider;
            this.IsActive = isActive;
        }

        public Subscriber() { }
    }
#elif NET9_0_OR_GREATER
    public record Subscriber(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("channel")] string Channel,
        [property: JsonPropertyName("userId")] string? UserId,
        [property: JsonPropertyName("username")] string? Username,
        [property: JsonPropertyName("userDisplayName")] string? UserDisplayName,
        [property: JsonPropertyName("userImage")] string? UserImage,
        [property: JsonPropertyName("userNumber")] int? UserNumber,
        [property: JsonPropertyName("fromName")] string? FromName,
        [property: JsonPropertyName("email")] string? Email,
        [property: JsonPropertyName("tierName")] string? TierName,
        [property: JsonPropertyName("amount")] string Amount,
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("message")] string Message,
        [property: JsonPropertyName("eventType")] string EventType,
        [property: JsonPropertyName("isFirstSubscriptionPayment")] bool IsFirstSubscriptionPayment,
        [property: JsonPropertyName("subscriberUntil")] string SubscriberUntil,
        [property: JsonPropertyName("createdAt")] string CreatedAt,
        [property: JsonPropertyName("provider")] string Provider,
        [property: JsonPropertyName("isActive")] bool IsActive
    );
#endif
}
