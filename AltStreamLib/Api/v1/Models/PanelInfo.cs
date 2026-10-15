using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
    public class PanelInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        public PanelInfo(int id, string slug, string title, string content, int displayOrder)
        {
            this.Id = id;
            this.Slug = slug;
            this.Title = title;
            this.Content = content;
            this.DisplayOrder = displayOrder;
        }

        public PanelInfo() { }
    }
}
