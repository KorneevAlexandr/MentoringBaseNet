using System.Text.Json;

namespace SerializationTasks.Serializers
{
    public class JsonFileSerializer : IFileSerializer
    {
        public T Serialize<T>(T item, string fileName)
        {
            return Serialize(item, new FileStream(fileName, FileMode.Create));
        }

        public T Serialize<T>(T item, Stream stream)
        {
            JsonSerializer.Serialize(stream, item);
            stream.Position = 0;

            return JsonSerializer.Deserialize<T>(stream);
        }
    }
}
