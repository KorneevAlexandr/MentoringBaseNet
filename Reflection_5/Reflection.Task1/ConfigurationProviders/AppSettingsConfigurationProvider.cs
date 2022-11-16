using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Reflection.Task1.ConfigurationProviders
{
    internal class AppSettingsConfigurationProvider : ConfigurationProvider
    {
        private readonly string _filePath;

        public AppSettingsConfigurationProvider(string filePath)
        {
            _filePath = filePath;
        }

        public override void Load()
        {
            var data = new Dictionary<string, string>();

            var content = File.ReadAllText(_filePath);
            var properties = JObject.Parse(content).Properties();

            foreach (var property in properties)
            {
                data[property.Name] = property.Value.ToString();
            }

            Data = data;
        }
    }
}
