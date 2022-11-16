using Microsoft.Extensions.Configuration;

namespace Reflection.Providers.ConfigurationProviders
{
    public class FileConfigurationSource : IConfigurationSource
    {
        private readonly string _filePath;

        public FileConfigurationSource(string filePath)
        {
            _filePath = filePath;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new FileConfigurationProvider(_filePath);
        }
    }
}
