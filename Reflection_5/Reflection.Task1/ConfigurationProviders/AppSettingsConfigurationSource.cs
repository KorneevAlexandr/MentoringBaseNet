using Microsoft.Extensions.Configuration;

namespace Reflection.Task1.ConfigurationProviders
{
    public class AppSettingsConfigurationSource : IConfigurationSource
    {
        private readonly string _filePath;

        public AppSettingsConfigurationSource(string filePath)
        {
            _filePath = filePath;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AppSettingsConfigurationProvider(_filePath);
        }
    }
}
