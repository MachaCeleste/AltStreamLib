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

        [JsonProperty("isSubscriber")]
        public bool IsSubscriber { get; set; }

        [JsonProperty("isAltStreamSupporter")]
        public bool IsAltStreamSupporter { get; set; }

        [JsonProperty("isChannelSupporter")]
        public bool IsChannelSupporter { get; set; }

        [JsonProperty("isSiteAdmin")]
        public bool IsSiteAdmin { get; set; }

        [JsonProperty("testerBadge")]
        public string TesterBadge { get; set; }

        [JsonProperty("channelPointsName")]
        public string ChannelPointsName { get; set; }

        public UserSettingsResponse(
            string name, string username, string image, string bio, string pronouns,
            string blueskyUrl, string websiteUrl, string discordUrl, string kofiUrl,
            string chatColor, List<GameInfo> gamingShelf, bool isSubscriber,
            bool isAltStreamSupporter, bool isChannelSupporter, bool isSiteAdmin,
            string testerBadge, string channelPointsName)
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
            this.IsSubscriber = isSubscriber;
            this.IsAltStreamSupporter = isAltStreamSupporter;
            this.IsChannelSupporter = isChannelSupporter;
            this.IsSiteAdmin = isSiteAdmin;
            this.TesterBadge = testerBadge;
            this.ChannelPointsName = channelPointsName;
        }

        public UserSettingsResponse() { }
    }
}
