namespace FileCabinet.Console.ConsoleComponents
{
    public static class ConsoleHelper
    {
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
