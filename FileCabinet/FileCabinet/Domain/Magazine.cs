namespace FileCabinet.Domain
{
    public class Magazine : DocumentBase
    {
        public Magazine()
            : base(nameof(DocumentTypes.Magazine))
        { }

        public int ReleaseNumber { get; set; }

        public string Publisher { get; set; }

        public DateTime DatePublished { get; set; }
    }
}
