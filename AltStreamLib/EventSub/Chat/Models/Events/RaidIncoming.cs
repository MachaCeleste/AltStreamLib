namespace AltStreamLib.EventSub.Chat.Models.Events
{
    public class RaidIncoming
    {
        public string SourceUsername { get; set; }
        public int Viewers { get; set; }

        public RaidIncoming(string sourceUsername, int viewers)
        {
            this.SourceUsername = sourceUsername;
            this.Viewers = viewers;
        }

        public RaidIncoming() { }
    }
}
