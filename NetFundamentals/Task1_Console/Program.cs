using Task2;

Console.Write("Enter your name: ");
var userName = Console.ReadLine();
Console.WriteLine($"Hello, {userName}!");

var helloFormatter = new HelloFormatter(userName);
var helloString = helloFormatter.Hello();
Console.WriteLine(helloString);