using FileCabinet.Console;
using FileCabinet.Console.ConsoleComponents;

var serviceProvider = DependencyInjection.GetServiceProvider();

var menu = (IMenu)serviceProvider.GetService(typeof(IMenu));
menu.Show();
