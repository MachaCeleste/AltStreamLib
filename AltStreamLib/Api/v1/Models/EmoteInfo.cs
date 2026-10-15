using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
    public class EmoteInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }

        public EmoteInfo(int id, string name, string url, int displayOrder)
        {
            this.Id = id;
            this.Name = name;
            this.Url = url;
            this.DisplayOrder = displayOrder;
        }

        public EmoteInfo() { }
    }
}