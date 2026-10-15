using Newtonsoft.Json;

namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class RaidCancel
    {
        [JsonProperty("sourceChannel")]
        public string SourceChannel { get; set; }

        public RaidCancel(string sourceChannel)
        {
            this.SourceChannel = sourceChannel;
        }

        public RaidCancel() { }
    }
}
