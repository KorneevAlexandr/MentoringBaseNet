using FileCabinet.Domain;

namespace FileCabinet.Console.ConsoleComponents
{
    public static class EntityEnterHelper
    {
        public static Book EnterBook() =>
            new Book
            {
                Title = ReadAsStringValue("Enter title: "),
                Isbn = ReadAsStringValue("Enter ISBN: "),
                Authors = ReadAsStringValue("Enter authors: "),
                OriginalPublisher = ReadAsStringValue("Enter publisher: "),
                NumberOfPages = ReadAsIntValue("Read number of pages: "),
                DatePublished = ReadAsDateTime("Enter date published: ")
            };

        public static LocalBook EnterLocalBook() =>
            new LocalBook
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

        public static Patent EnterPatent() => 
            new Patent
            {
                Title = ReadAsStringValue("Enter title: "),
                Authors = ReadAsStringValue("Enter authors: "),
                DatePublished = ReadAsDateTime("Enter date published: "),
                DateExpiration = ReadAsDateTime("Enter date expiration: ")
            };

        public static DateTime ReadAsDateTime(string title)
        {
            System.Console.WriteLine(title);

            var parseCorrect = false;
            DateTime result = DateTime.MinValue;

            while (!parseCorrect)
            {
                System.Console.Write("> ");
                var value = System.Console.ReadLine();

                parseCorrect = DateTime.TryParse(value, out result);
            }

            return result;
        }

        public static string ReadAsStringValue(string title)
        {
            System.Console.WriteLine(title);
            var value = string.Empty;

            while (value == string.Empty)
            {
                System.Console.Write("> ");
                value = System.Console.ReadLine();
            }

            return value;
        }

        public static int ReadAsIntValue(string title)
        {
            System.Console.WriteLine(title);

            var parseCorrect = false;
            var result = 0;

            while (!parseCorrect)
            {
                System.Console.Write("> ");
                var value = System.Console.ReadLine();

                parseCorrect = int.TryParse(value, out result);
            }

            return result;
        }
    }
}
