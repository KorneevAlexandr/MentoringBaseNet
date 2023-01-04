using FileCabinet.Console.ConsoleComponents.DocumentFormatters;

namespace FileCabinet.Console.Extensions
{
    public static class ConsoleExtensions
    {
        public static void Show<T>(this IEnumerable<T> items, IDocumentFormatter<T> formatter)
        {
            System.Console.WriteLine();

            foreach (var item in items)
            {
                formatter.Write(item);
            }
        }
    }
}
