using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTasks.Serializers
{
    public class BinaryFileSerializer : IFileSerializer
    {
        public T Serialize<T>(T item, string fileName)
        {
            return Serialize(item, new FileStream(fileName, FileMode.Create));
        }

        public T Serialize<T>(T item, Stream stream)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, item);
            stream.Position = 0;

            var result = (T)formatter.Deserialize(stream);
            return result;
        }
    }
}
