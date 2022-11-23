namespace Reflection.Task1.Attributes
{
    public class ConfigurationItemAttribute : Attribute
    {
        public ConfigurationItemAttribute(string configurationItemName, string configurationProviderType)
        {
            ConfigurationItemName = configurationItemName;
            ConfigurationProviderType = configurationProviderType;
        }

        public string ConfigurationItemName { get; }

        public string ConfigurationProviderType { get; }
    }
}
