namespace FileCabinet.Domain
{
    public class LocalBook : DocumentBase, IIsbn
    {
        public LocalBook()
            : base(nameof(DocumentTypes.LocalBook))
        { }

        public string Isbn { get; set; }

        public string Authors { get; set; }

        public int NumberOfPages { get; set; }

        public string OriginalPublisher { get; set; }

        public string Country { get; set; }

        public string LocalPublisher { get; set; }

        public DateTime DatePublished { get; set; }
    }
}
