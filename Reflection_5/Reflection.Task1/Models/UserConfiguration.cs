using Microsoft.Extensions.Configuration;
using Reflection.Task1.Attributes;
using Reflection.Task1.ConfigurationProviders;

namespace Reflection.Task1.Models
{
    public class UserConfiguration : BaseConfigurationItem
    {
        public UserConfiguration(IConfigurationRoot configuration) 
            : base(configuration) { }

        [ConfigurationItem(nameof(Id), typeof(AppSettingsConfigurationProvider))]
        public int Id { get; set; }

        [ConfigurationItem(nameof(Name), typeof(FileConfigurationProvider))]
        public string Name { get; set; }

        [ConfigurationItem(nameof(Surname), typeof(FileConfigurationProvider))]
        public string Surname { get; set; }

        [ConfigurationItem(nameof(Age), typeof(FileConfigurationProvider))]
        public int Age { get; set; }
    }
}
