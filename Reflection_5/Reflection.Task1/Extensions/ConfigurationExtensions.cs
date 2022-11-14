using Microsoft.Extensions.Configuration;
using Reflection.Task1.ConfigurationProviders;
using Reflection.Task1.Models;

namespace Reflection.Task1.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddConfigurationProviderFromFile(this IConfigurationBuilder builder, string path)
        {
            ValidateRegisterParameters(builder, path);

            var source = new FileConfigurationSource(path);
            builder.Add(source);

            return builder;
        }

        public static T GetConfigurationItem<T>(this IConfigurationRoot configuration)
            where T : BaseConfigurationItem
        {
            var configurationItem = (T)Activator.CreateInstance(typeof(T), configuration);
            configurationItem.LoadConfiguration();

            return configurationItem;
        }

        private static void ValidateRegisterParameters(IConfigurationBuilder builder, string path)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path doesn't specified.");
            }
        }
    }
}
