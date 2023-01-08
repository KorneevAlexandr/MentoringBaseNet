using FileCabinet.Domain;
using static FileCabinet.Console.ConsoleComponents.ConsoleHelper;

namespace FileCabinet.Console.ConsoleComponents.DocumentFormatters
{
    public class MagazineFormatter : IDocumentFormatter<Magazine>
    {
        public Magazine Read()
        {
            return new Magazine
            {
                Title = ReadAsStringValue("Enter title: "),
                Publisher = ReadAsStringValue("Enter publisher: "),
                ReleaseNumber = ReadAsIntValue("Enter release number: "),
                DatePublished = ReadAsDateTime("Enter date published: ")
            };
        }

        public void Write(Magazine magazine)
        {
            System.Console.WriteLine(
                $" * {magazine.Type} * \n" +
                $"Id - {magazine.Id}\n" +
                $"Title - {magazine.Title}\n" +
                $"Release number - {magazine.ReleaseNumber}\n" +
                $"Publisher - {magazine.Publisher}\n" +
                $"Date published - {magazine.DatePublished.ToShortDateString()}\n");
        }
    }
}
