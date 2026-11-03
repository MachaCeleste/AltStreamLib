using Newtonsoft.Json;

namespace AltStreamLib.Api.Live.Models
{
    public class UpdateTitleRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    
        [JsonProperty("title")]
        public string Title { get; set; }
    
        [JsonProperty("username")]
        public string Username { get; set; }

        public UpdateTitleRequest(string key, string title, string username)
        {
            this.Key = key;
            this.Title = title;
            this.Username = username;
        }

        public UpdateTitleRequest() { }
    }
}
