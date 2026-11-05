using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models
{
    public class Raid
    {
        [JsonProperty("from")]
        public Author From { get; set; }
    
        [JsonProperty("viewers")]
        public int Viewers { get; set; }

        public Raid(Author from, int viewers)
        {
            this.From = from;
            this.Viewers = viewers;
        }

        public Raid() { }
    }
}
