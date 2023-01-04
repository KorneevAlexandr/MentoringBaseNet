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
