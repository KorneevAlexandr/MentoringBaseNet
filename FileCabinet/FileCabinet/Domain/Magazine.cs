namespace FileCabinet.Domain
{
    public class Magazine : DocumentBase
    {
        public Magazine()
            : base(typeof(Magazine).Name)
        { }

        public int ReleaseNumber { get; set; }

        public string Publisher { get; set; }

        public DateTime DatePublished { get; set; }
    }
}
