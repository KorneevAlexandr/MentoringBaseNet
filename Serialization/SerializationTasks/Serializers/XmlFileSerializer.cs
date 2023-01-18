using System.Xml.Serialization;

namespace SerializationTasks.Serializers
{
    public class XmlFileSerializer : IFileSerializer
    {
        public T Serialize<T>(T item, string fileName)
        {
            return Serialize(item, new FileStream(fileName, FileMode.Create));
        }

        public T Serialize<T>(T item, Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, item);
            stream.Position = 0;

            var result = (T)serializer.Deserialize(stream);
            return result;
        }
    }
}
