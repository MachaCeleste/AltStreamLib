#if NET461 || NET472 || NET481
using System.Collections.Generic;
using Newtonsoft.Json;
#elif NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace AltStreamLib.Api.Models.v1
{
#if NET461 || NET472 || NET481
    public class UserSettingsResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("pronouns")]
        public string Pronouns { get; set; }

        [JsonProperty("blueskyUrl")]
        public string BlueskyUrl { get; set; }

        [JsonProperty("websiteUrl")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("discordUrl")]
        public string DiscordUrl { get; set; }

        [JsonProperty("kofiUrl")]
        public string KofiUrl { get; set; }

        [JsonProperty("bmacUrl")]
        public string BmacUrl { get; set; }

        [JsonProperty("featuredSupportProvider")]
        public string FeaturedSupportProvider { get; set; }

        [JsonProperty("vgenUrl")]
        public string VgenUrl { get; set; }
    
        [JsonProperty("chatColor")]
        public string ChatColor { get; set; }

        [JsonProperty("gamingShelf")]
        public List<GameInfo> GamingShelf { get; set; }

        [JsonProperty("offlineImage")]
        public string OfflineImage { get; set; }

        [JsonProperty("headerImage")]
        public string HeaderImage { get; set; }

        [JsonProperty("isSubscriber")]
        public bool IsSubscriber { get; set; }

        [JsonProperty("isChannelSubscriber")]
        public bool IsChannelSubscriber { get; set; }

        [JsonProperty("isAltStreamSupporter")]
        public bool IsAltStreamSupporter { get; set; }

        [JsonProperty("altStreamSupporterTier")]
        public string AltStreamSupporterTier { get; set; }

        [JsonProperty("supporterStickerBonus")]
        public int SupporterStickerBonus { get; set; }

        [JsonProperty("isChannelSupporter")]
        public bool IsChannelSupporter { get; set; }

        [JsonProperty("channelBadgeImage")]
        public string ChannelBadgeImage { get; set; }

        [JsonProperty("channelSupporterBadgeImage")]
        public string ChannelSupporterBadgeImage { get; set; }

        [JsonProperty("isSiteAdmin")]
        public bool IsSiteAdmin { get; set; }

        [JsonProperty("followedAt")]
        public string FollowedAt { get; set; }

        [JsonProperty("bannedUntil")]
        public string BannedUntil { get; set; }

        [JsonProperty("userNumber")]
        public int UserNumber { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("testerBadge")]
        public string TesterBadge { get; set; }

        [JsonProperty("referralCount")]
        public int ReferralCount { get; set; }

        [JsonProperty("isReferralBadgeUnlocked")]
        public bool IsReferralBadgeUnlocked { get; set; }

        [JsonProperty("channelPointsName")]
        public string ChannelPointsName { get; set; }

        [JsonProperty("selectedBadges")]
        public string[] SelectedBadges { get; set; }

        [JsonProperty("requireLoginToWatch")]
        public bool RequireLoginToWatch { get; set; }
    
        [JsonProperty("allStreamsAdult")]
        public bool AllStreamsAdult { get; set; }
    
        [JsonProperty("ageVerified")]
        public bool AgeVerified { get; set; }
    
        [JsonProperty("ageVerifiedAt")]
        public string AgeVerifiedAt { get; set; }
    
        [JsonProperty("ageVerificationProvider")]
        public string AgeVerificationProvider { get; set; }
    
        [JsonProperty("discordUsername")]
        public string DiscordUsername { get; set; }
    
        [JsonProperty("twitchUsername")]
        public string TwitchUsername { get; set; }
    
        [JsonProperty("hasDiscordLinked")]
        public bool HasDiscordLinked { get; set; }
    
        [JsonProperty("hasTwitchLinked")]
        public bool HasTwitchLinked { get; set; }
    
        [JsonProperty("discordWebhookUrl")]
        public string DiscordWebhookUrl { get; set; }
    
        [JsonProperty("discordWebhookMessage")]
        public string DiscordWebhookMessage { get; set; }
    
        [JsonProperty("discordWebhookEnabled")]
        public bool DiscordWebhookEnabled { get; set; }
    
        [JsonProperty("discordWebhookMention")]
        public string DiscordWebhookMention { get; set; }
    
        [JsonProperty("discordWebhookRoleId")]
        public string DiscordWebhookRoleId { get; set; }
    
        [JsonProperty("discordWebhookColor")]
        public string DiscordWebhookColor { get; set; }
    
        [JsonProperty("discordWebhookThumbnail")]
        public string DiscordWebhookThumbnail { get; set; }
    
        [JsonProperty("discordWebhookBanner")]
        public string DiscordWebhookBanner { get; set; }
    
        [JsonProperty("kofiVerificationToken")]
        public string KofiVerificationToken { get; set; }

        [JsonProperty("bmacWebhookSecret")]
        public string BmacWebhookSecret { get; set; }

        [JsonProperty("myReferralCode")]
        public string MyReferralCode { get; set; }
    
        [JsonProperty("referredBy")]
        public Referer ReferredBy { get; set; }


        public UserSettingsResponse(
            string name, string username, string image, string bio, string pronouns,
            string blueskyUrl, string websiteUrl, string discordUrl,
            string kofiUrl, string bmacUrl, string featuredSupportProvider, string vgenUrl,
            string chatColor, List<GameInfo> gamingShelf, string offlineImage, string headerImage,
            bool isSubscriber, bool isChannelSubscriber, bool isAltStreamSupporter, string altStreamSupporterTier, int supporterStickerBonus,
            bool isChannelSupporter, string channelBadgeImage, string channelSupporterBadgeImage, bool isSiteAdmin,
            string followedAt, string bannedUntil, int userNumber, string testerBadge, int referralCount,
            bool isReferralBadgeUnlocked, string channelPointsName, string[] selectedBadges, bool requireLoginToWatch,
            bool allStreamsAdult, bool ageVerified, string ageVerifiedAt, string ageVerificationProvider,
            string discordUsername, string twitchUsername, bool hasDiscordLinked, bool hasTwitchLinked,
            string discordWebhookUrl, string discordWebhookMessage, bool discordWebhookEnabled, string discordWebhookMention,
            string discordWebhookColor, string discordWebhookThumbnail, string discordWebhookBanner, string kofiVerificationToken,
            string bmacWebhookSecret, string myReferralCode, Referer referredBy)
        {
            this.Name = name;
            this.Username = username;
            this.Image = image;
            this.Bio = bio;
            this.Pronouns = pronouns;
            this.BlueskyUrl = blueskyUrl;
            this.WebsiteUrl = websiteUrl;
            this.DiscordUrl = discordUrl;
            this.KofiUrl = kofiUrl;
            this.BmacUrl = bmacUrl;
            this.FeaturedSupportProvider = featuredSupportProvider;
            this.VgenUrl = vgenUrl;
            this.ChatColor = chatColor;
            this.GamingShelf = gamingShelf;
            this.OfflineImage = offlineImage;
            this.HeaderImage = headerImage;
            this.IsSubscriber = isSubscriber;
            this.IsChannelSubscriber = isChannelSubscriber;
            this.IsAltStreamSupporter = isAltStreamSupporter;
            this.AltStreamSupporterTier = altStreamSupporterTier;
            this.SupporterStickerBonus = supporterStickerBonus;
            this.IsChannelSupporter = isChannelSupporter;
            this.ChannelBadgeImage = channelBadgeImage;
            this.ChannelSupporterBadgeImage = channelSupporterBadgeImage;
            this.IsSiteAdmin = isSiteAdmin;
            this.FollowedAt = followedAt;
            this.BannedUntil = bannedUntil;
            this.UserNumber = userNumber;
            this.TesterBadge = testerBadge;
            this.ReferralCount = referralCount;
            this.IsReferralBadgeUnlocked = isReferralBadgeUnlocked;
            this.ChannelPointsName = channelPointsName;
            this.SelectedBadges = selectedBadges;
            this.RequireLoginToWatch = requireLoginToWatch;
            this.AllStreamsAdult = allStreamsAdult;
            this.AgeVerified = ageVerified;
            this.AgeVerifiedAt = ageVerifiedAt;
            this.AgeVerificationProvider = ageVerificationProvider;
            this.DiscordUsername = discordUsername;
            this.TwitchUsername = twitchUsername;
            this.HasDiscordLinked = hasDiscordLinked;
            this.HasTwitchLinked = hasTwitchLinked;
            this.DiscordWebhookUrl = discordWebhookUrl;
            this.DiscordWebhookMessage = discordWebhookMessage;
            this.DiscordWebhookEnabled = discordWebhookEnabled;
            this.DiscordWebhookMention = discordWebhookMention;
            this.DiscordWebhookColor = discordWebhookColor;
            this.DiscordWebhookThumbnail = discordWebhookThumbnail;
            this.DiscordWebhookBanner = discordWebhookBanner;
            this.KofiVerificationToken = kofiVerificationToken;
            this.BmacWebhookSecret = bmacWebhookSecret;
            this.MyReferralCode = myReferralCode;
            this.ReferredBy = referredBy;
        }

        public UserSettingsResponse() { }
    }
#elif NET9_0_OR_GREATER
    public record UserSettingsResponse(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("username")] string? Username,
        [property: JsonPropertyName("image")] string? Image,
        [property: JsonPropertyName("bio")] string? Bio,
        [property: JsonPropertyName("pronouns")] string? Pronouns,
        [property: JsonPropertyName("blueskyUrl")] string? BlueskyUrl,
        [property: JsonPropertyName("websiteUrl")] string? WebsiteUrl,
        [property: JsonPropertyName("discordUrl")] string? DiscordUrl,
        [property: JsonPropertyName("kofiUrl")] string? KofiUrl,
        [property: JsonPropertyName("bmacUrl")] string? BmacUrl,
        [property: JsonPropertyName("featuredSupportProvider")] string? FeaturedSupportProvider,
        [property: JsonPropertyName("vgenUrl")] string? VgenUrl,
        [property: JsonPropertyName("chatColor")] string? ChatColor,
        [property: JsonPropertyName("gamingShelf")] List<GameInfo> GamingShelf,
        [property: JsonPropertyName("offlineImage")] string? OfflineImage,
        [property: JsonPropertyName("headerImage")] string? HeaderImage,
        [property: JsonPropertyName("isSubscriber")] bool IsSubscriber,
        [property: JsonPropertyName("isChannelSubscriber")] bool IsChannelSubscriber,
        [property: JsonPropertyName("isAltStreamSupporter")] bool IsAltStreamSupporter,
        [property: JsonPropertyName("altStreamSupporterTier")] string? AltStreamSupporterTier,
        [property: JsonPropertyName("supporterStickerBonus")] int? SupporterStickerBonus,
        [property: JsonPropertyName("isChannelSupporter")] bool IsChannelSupporter,
        [property: JsonPropertyName("channelBadgeImage")] string? ChannelBadgeImage,
        [property: JsonPropertyName("channelSupporterBadgeImage")] string? ChannelSupporterBadgeImage,
        [property: JsonPropertyName("isSiteAdmin")] bool IsSiteAdmin,
        [property: JsonPropertyName("followedAt")] string? FollowedAt,
        [property: JsonPropertyName("bannedUntil")] string? BannedUntil,
        [property: JsonPropertyName("userNumber")] int? UserNumber,
        [property: JsonPropertyName("createdAt")] string? CreatedAt,
        [property: JsonPropertyName("testerBadge")] string? TesterBadge,
        [property: JsonPropertyName("referralCount")] int? ReferralCount,
        [property: JsonPropertyName("isReferralBadgeUnlocked")] bool? IsReferralBadgeUnlocked,
        [property: JsonPropertyName("channelPointsName")] string? ChannelPointsName,
        [property: JsonPropertyName("selectedBadges")] string[] SelectedBadges,
        [property: JsonPropertyName("requireLoginToWatch")] bool? RequireLoginToWatch,
        [property: JsonPropertyName("allStreamsAdult")] bool? AllStreamsAdult,
        [property: JsonPropertyName("ageVerified")] bool? AgeVerified,
        [property: JsonPropertyName("ageVerifiedAt")] string? AgeVerifiedAt,
        [property: JsonPropertyName("ageVerificationProvider")] string? AgeVerificationProvider,
        [property: JsonPropertyName("discordUsername")] string? DiscordUsername,
        [property: JsonPropertyName("twitchUsername")] string? TwitchUsername,
        [property: JsonPropertyName("hasDiscordLinked")] bool? HasDiscordLinked,
        [property: JsonPropertyName("hasTwitchLinked")] bool? HasTwitchLinked,
        [property: JsonPropertyName("discordWebhookUrl")] string? DiscordWebhookUrl,
        [property: JsonPropertyName("discordWebhookMessage")] string? DiscordWebhookMessage,
        [property: JsonPropertyName("discordWebhookEnabled")] bool? DiscordWebhookEnabled,
        [property: JsonPropertyName("discordWebhookMention")] string? DiscordWebhookMention,
        [property: JsonPropertyName("discordWebhookRoleId")] string? DiscordWebhookRoleId,
        [property: JsonPropertyName("discordWebhookColor")] string? DiscordWebhookColor,
        [property: JsonPropertyName("discordWebhookThumbnail")] string? DiscordWebhookThumbnail,
        [property: JsonPropertyName("discordWebhookBanner")] string? DiscordWebhookBanner,
        [property: JsonPropertyName("kofiVerificationToken")] string? KofiVerificationToken,
        [property: JsonPropertyName("bmacWebhookSecret")] string? BmacWebhookSecret,
        [property: JsonPropertyName("myReferralCode")] string? MyReferralCode,
        [property: JsonPropertyName("referredBy")] Referer? ReferredBy
    );
#endif
}
