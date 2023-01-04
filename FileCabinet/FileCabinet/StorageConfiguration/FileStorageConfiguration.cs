using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinet.StorageConfiguration
{
    public class FileStorageConfiguration : IFileStorageConfiguration
    {
        public FileStorageConfiguration(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public string DirectoryPath { get; private set; }
    }
}
