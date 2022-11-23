using Microsoft.Extensions.Configuration;
using Reflection.Task1.Models;

namespace Reflection.Task1.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetConfigurationItem<T>(this IConfigurationRoot configuration)
            where T : BaseConfigurationItem
        {
            var configurationItem = (T)Activator.CreateInstance(typeof(T), configuration);
            configurationItem.LoadConfiguration();

            return configurationItem;
        }
    }
}
