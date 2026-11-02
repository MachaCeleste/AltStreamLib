using Newtonsoft.Json;

namespace AltStreamLib.Api.v1.Models
{
    public class Referer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }

        public Referer(string id, string username, string name)
        {
            this.Id = id;
            this.Username = username;
            this.Name = name;
        }

        public Referer() { }
    }
}
