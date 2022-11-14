namespace Reflection.Task1.Attributes
{
    public class ConfigurationItemAttribute : Attribute
    {
        public ConfigurationItemAttribute(string configurationItemName, Type configurationProviderType)
        {
            ConfigurationItemName = configurationItemName;
            ConfigurationProviderType = configurationProviderType;
        }

        public string ConfigurationItemName { get; }

        public Type ConfigurationProviderType { get; }
    }
}
