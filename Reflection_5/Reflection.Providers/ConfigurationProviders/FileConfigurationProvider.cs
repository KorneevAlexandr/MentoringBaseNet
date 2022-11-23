using Microsoft.Extensions.Configuration;

namespace Reflection.Providers.ConfigurationProviders
{
    public class FileConfigurationProvider : ConfigurationProvider
    {
        private readonly string _filePath;

        public FileConfigurationProvider(string filePath)
        {
            _filePath = filePath;
        }

        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                using (StreamReader textReader = new StreamReader(fs))
                {
                    string line;

                    while ((line = textReader.ReadLine()) != null)
                    {
                        string key = line.Trim();
                        string value = textReader.ReadLine();
                        data.Add(key, value);
                    }
                }
            }

            Data = data;
        }
    }
}
