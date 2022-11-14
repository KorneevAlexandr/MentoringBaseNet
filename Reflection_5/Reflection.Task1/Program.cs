using Microsoft.Extensions.Configuration;
using Reflection.Task1.Extensions;
using Reflection.Task1.Models;

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddConfigurationProviderFromFile("hello.txt");
var configuration = configurationBuilder.Build();

var userConfiguration = configuration.GetConfigurationItem<UserConfiguration>();
Console.ReadLine();


