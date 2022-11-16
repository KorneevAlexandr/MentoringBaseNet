using Microsoft.Extensions.Configuration;
using Reflection.Task1.Extensions;
using Reflection.Task1.Models;

var configuration = new ConfigurationBuilder()
    .AddFileConfigurationProvider("filesettings.txt")
    .AddAppSettingsConfigurationProvider("appsettings.json")
    .Build();

var userConfiguration = configuration.GetConfigurationItem<UserConfiguration>();
Console.ReadLine();


