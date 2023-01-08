using FileCabinet.Console;
using FileCabinet.Console.ConsoleComponents;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = DependencyInjection.GetServiceProvider();

var menu = serviceProvider.GetService<IMenu>();
menu.Show();
