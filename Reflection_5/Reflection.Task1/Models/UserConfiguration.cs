using Microsoft.Extensions.Configuration;
using Reflection.Task1.Attributes;
using Reflection.Task1.DllLoaders;

namespace Reflection.Task1.Models
{
    public class UserConfiguration : BaseConfigurationItem
    {
        public UserConfiguration(IConfigurationRoot configuration) 
            : base(configuration) { }

        [ConfigurationItem(nameof(Id), ConfigurationProviderLoader.AppSettingsConfigurationProviderName)]
        public int Id { get; set; }

        [ConfigurationItem(nameof(Name), ConfigurationProviderLoader.FileConfigurationProviderName)]
        public string Name { get; set; }

        [ConfigurationItem(nameof(Surname), ConfigurationProviderLoader.FileConfigurationProviderName)]
        public string Surname { get; set; }

        [ConfigurationItem(nameof(Age), ConfigurationProviderLoader.FileConfigurationProviderName)]
        public int Age { get; set; }

        [ConfigurationItem(nameof(Time), ConfigurationProviderLoader.FileConfigurationProviderName)]
        public TimeSpan Time { get; set; }
    }
}
