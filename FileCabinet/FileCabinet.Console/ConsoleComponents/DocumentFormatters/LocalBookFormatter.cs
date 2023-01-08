using FileCabinet.Domain;
using static FileCabinet.Console.ConsoleComponents.ConsoleHelper;

namespace FileCabinet.Console.ConsoleComponents.DocumentFormatters
{
    public class LocalBookFormatter : IDocumentFormatter<LocalBook>
    {
        public LocalBook Read()
        {
            return new LocalBook
            {
                Title = ReadAsStringValue("Enter title: "),
                Isbn = ReadAsStringValue("Enter ISBN: "),
                Authors = ReadAsStringValue("Enter authors: "),
                OriginalPublisher = ReadAsStringValue("Enter publisher: "),
                NumberOfPages = ReadAsIntValue("Read number of pages: "),
                DatePublished = ReadAsDateTime("Enter date published: "),
                Country = ReadAsStringValue("Enter country: "),
                LocalPublisher = ReadAsStringValue("Enter local publisher: ")
            };
        }

        public void Write(LocalBook book)
        {
            System.Console.WriteLine(
                $" * {book.Type} * \n" +
                $"Id - {book.Id}\n" +
                $"ISBN - {book.Isbn}\n" +
                $"Title - {book.Title}\n" +
                $"Pages - {book.NumberOfPages}\n" +
                $"Authors - {book.Authors}\n" +
                $"Publisher - {book.OriginalPublisher}\n" +
                $"Date published - {book.DatePublished.ToShortDateString()}\n" +
                $"Country - {book.Country}\n" +
                $"Local publisher - {book.LocalPublisher}\n");
        }
    }
}
