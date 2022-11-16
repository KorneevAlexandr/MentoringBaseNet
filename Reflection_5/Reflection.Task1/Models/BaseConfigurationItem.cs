using Microsoft.Extensions.Configuration;
using Reflection.Task1.Attributes;
using System.Reflection;

namespace Reflection.Task1.Models
{
    public abstract class BaseConfigurationItem
    {
        public BaseConfigurationItem(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        protected IConfigurationRoot Configuration { get; }

        protected internal void LoadConfiguration()
        {
            var type = GetType();
            var properties = type.GetProperties();
            
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    if (attribute is ConfigurationItemAttribute itemAttribute)
                    {
                        SaveValueForPropety(property, itemAttribute);
                    }
                }
            }
        }

        private void SaveValueForPropety(PropertyInfo property, ConfigurationItemAttribute itemAttribute)
        {
            var provider = Configuration.Providers.First(p => p.GetType().Name.Equals(itemAttribute.ConfigurationProviderType));

            if (provider == null)
            {
                throw new InvalidOperationException("Specified provider not register.");
            }

            if (provider.TryGet(itemAttribute.ConfigurationItemName, out string value))
            {
                object typedValue;

                try
                {
                    typedValue = Convert.ChangeType(value, property.PropertyType);
                }
                catch
                {
                    throw new InvalidOperationException("Specified setting not map on specified type.");
                }

                property.SetValue(this, typedValue);
            }
            else
            {
                throw new InvalidOperationException("Specified setting name not exist.");
            }
        }
    }
}
