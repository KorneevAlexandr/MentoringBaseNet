namespace FileCabinet.Domain
{
    public class Book : DocumentBase, IIsbn
    {
        public Book() 
            : base(typeof(Book).Name)
        { }

        public string Isbn { get; set; }

        public string Authors { get; set; }

        public int NumberOfPages { get; set; }

        public string OriginalPublisher { get; set; }

        public DateTime DatePublished { get; set; }
    }
}
