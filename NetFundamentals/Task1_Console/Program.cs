using Task2;

Console.Write("Enter your name: ");
var userName = Console.ReadLine();
Console.WriteLine($"Hello, {userName}!");

var helloFormatter = new HelloFormatter();
var helloString = helloFormatter.Hello(userName);
Console.WriteLine(helloString);