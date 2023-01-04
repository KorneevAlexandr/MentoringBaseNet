namespace FileCabinet.Domain
{
    public class Patent : DocumentBase
    {
        public Patent()
            : base(nameof(DocumentTypes.Patent))
        { }

        public string Authors { get; set; }

        public DateTime DatePublished { get; set; }

        public DateTime DateExpiration { get; set; }
    }
}
