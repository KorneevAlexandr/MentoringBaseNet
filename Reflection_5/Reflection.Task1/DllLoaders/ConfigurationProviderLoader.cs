using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Reflection.Task1.DllLoaders
{
    internal class ConfigurationProviderLoader
    {
        private const string ConfigurationProviderDllName = "Reflection.Providers.dll";

        private const string FileConfigurationSourceName = "FileConfigurationSource";
        private const string AppSettingsConfigurationSourceName = "AppSettingsConfigurationSource";

        internal const string FileConfigurationProviderName = "FileConfigurationProvider";
        internal const string AppSettingsConfigurationProviderName = "AppSettingsConfigurationProvider";

        private readonly static Assembly ProvidersAssembly = Assembly.LoadFrom(ConfigurationProviderDllName);

        private readonly ConfigurationBuilder _builder;

        public ConfigurationProviderLoader()
        {
            _builder = new ConfigurationBuilder();
        }

        public void AddFileConfigurationProvider(string fileName) => 
            AddConfigurationProvider(FileConfigurationSourceName, fileName);

        public void AddAppSettingsConfigurationProvider(string fileName) =>
            AddConfigurationProvider(AppSettingsConfigurationSourceName, fileName);

        public IConfigurationRoot GetConfigurationRoot() => _builder.Build();

        private void AddConfigurationProvider(string configurationProviderName, string fileName)
        {
            var configurationSourceType = ProvidersAssembly.GetTypes().FirstOrDefault(x => x.Name.Equals(configurationProviderName));

            if (configurationSourceType != null)
            {
                try
                {
                    var configurationSource = (IConfigurationSource)Activator.CreateInstance(configurationSourceType, fileName);
                    _builder.Add(configurationSource);
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                throw new InvalidOperationException("Can not load specified type from another assembly.");
            }
        }
    }
}
