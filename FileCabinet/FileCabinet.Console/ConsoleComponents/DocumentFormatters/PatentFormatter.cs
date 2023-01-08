using FileCabinet.Domain;
using static FileCabinet.Console.ConsoleComponents.ConsoleHelper;

namespace FileCabinet.Console.ConsoleComponents.DocumentFormatters
{
    public class PatentFormatter : IDocumentFormatter<Patent>
    {
        public Patent Read()
        {
            return new Patent
            {
                Title = ReadAsStringValue("Enter title: "),
                Authors = ReadAsStringValue("Enter authors: "),
                DatePublished = ReadAsDateTime("Enter date published: "),
                DateExpiration = ReadAsDateTime("Enter date expiration: ")
            };
        }

        public void Write(Patent patent)
        {
            System.Console.WriteLine(
                $" * {patent.Type} * \n" +
                $"Id - {patent.Id}\n" +
                $"Title - {patent.Title}\n" +
                $"Authors - {patent.Authors}\n" +
                $"Date published - {patent.DatePublished.ToShortDateString()}\n" +
                $"Date expiration - {patent.DateExpiration.ToShortDateString()}\n");
        }
    }
}
