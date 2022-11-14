using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Reflection.Task1.ConfigurationProviders
{
    internal class AppSettingsProvider : ConfigurationProvider
    {
        private readonly string _filePath;

        public AppSettingsProvider(string filePath)
        {
            _filePath = filePath;
        }

        public override void Load()
        {
        }
    }
}
