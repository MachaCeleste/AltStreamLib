using System.Collections.Generic;
using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
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

        [JsonProperty("isAltStreamSupporter")]
        public bool IsAltStreamSupporter { get; set; }

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

        public UserSettingsResponse(
            string name, string username, string image, string bio, string pronouns,
            string blueskyUrl, string websiteUrl, string discordUrl, string kofiUrl,
            string chatColor, List<GameInfo> gamingShelf, string offlineImage, string headerImage,
            bool isSubscriber, bool isAltStreamSupporter, bool isChannelSupporter, string channelBadgeImage, 
            string channelSupporterBadgeImage, bool isSiteAdmin, string followedAt, string bannedUntil, int userNumber,
            string testerBadge, int referralCount, bool isReferralBadgeUnlocked, string channelPointsName)
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
            this.ChatColor = chatColor;
            this.GamingShelf = gamingShelf;
            this.OfflineImage = offlineImage;
            this.HeaderImage = headerImage;
            this.IsSubscriber = isSubscriber;
            this.IsAltStreamSupporter = isAltStreamSupporter;
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
        }

        public UserSettingsResponse() { }
    }
}
