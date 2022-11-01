using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEnter the line: ");
                var line = Console.ReadLine();

                try
                {
                    Console.WriteLine(line[0]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Input string was null.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong: {ex.Message}");
                }
            }
        }
    }
}