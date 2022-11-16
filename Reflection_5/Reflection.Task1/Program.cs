using Reflection.Task1.DllLoaders;
using Reflection.Task1.Extensions;
using Reflection.Task1.Models;

string basePath = Directory.GetCurrentDirectory();

var configurationLoader = new ConfigurationProviderLoader();
configurationLoader.AddFileConfigurationProvider($"{basePath}/filesettings.txt");
configurationLoader.AddAppSettingsConfigurationProvider($"{basePath}/appsettings.json");

var configuration = configurationLoader.GetConfigurationRoot();

var userConfiguration = configuration.GetConfigurationItem<UserConfiguration>();
Console.ReadLine();
