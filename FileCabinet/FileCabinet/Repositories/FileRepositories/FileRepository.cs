using System.Collections.Immutable;
using Newtonsoft.Json;
using FileCabinet.Domain;
using FileCabinet.StorageConfiguration;

namespace FileCabinet.Repositories.FileRepositories
{
    public class FileRepository<T> : IRepository<T>
        where T : DocumentBase
    {
        private readonly IFileStorageConfiguration _fileStorageConfiguration;

        public FileRepository(IFileStorageConfiguration fileStorageConfiguration)
        {
            _fileStorageConfiguration = fileStorageConfiguration;
        }

        public IEnumerable<T> GetAll()
        {
            var directoryInfo = new DirectoryInfo(_fileStorageConfiguration.DirectoryPath);
            var files = directoryInfo.GetFiles();

            var documents = ImmutableList<T>.Empty;

            Parallel.ForEach(files, file =>
            {
                using var fileStream = file.OpenRead();
                using var streamReader = new StreamReader(fileStream);
                var content = streamReader.ReadToEnd();

                documents.Add(JsonConvert.DeserializeObject<T>(content));
            });

            return documents;
        }

        public T GetById(string id)
        {
            var documents = GetAll();

            return documents.FirstOrDefault(x => x.Id.Equals(id));
        }

        public string Create(T entity)
        {
            entity.Id = Guid.NewGuid().ToString("N");
            var content = JsonConvert.SerializeObject(entity);
            var filePath = GetFilePath(entity);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            using var streamWriter = new StreamWriter(fileStream);

            streamWriter.Write(content);

            return entity.Id;
        }

        public void Update(T entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var filePath = GetFilePath(entity);

            using var fileStream = new FileStream(filePath, FileMode.CreateNew);
            using var streamWriter = new StreamWriter(fileStream);

            streamWriter.Write(content);
        }

        public void Delete(T entity)
        {
            var filePath = GetFilePath(entity);
            var fileInfo = new FileInfo(filePath);

            fileInfo.Delete();
        }

        private string GetFilePath(T entity) => $"{_fileStorageConfiguration}{entity.Type}#{entity.Id}.json";
    }
}
