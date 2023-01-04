namespace FileCabinet.Domain
{
    public class Book : DocumentBase
    {
        public Book() 
            : base(nameof(DocumentTypes.Book))
        { }

        public string Isbn { get; set; }

        public string Authors { get; set; }

        public int NumberOfPages { get; set; }

        public string OriginalPublisher { get; set; }

        public DateTime DatePublished { get; set; }
    }
}
