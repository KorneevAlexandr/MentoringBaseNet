namespace SerializationTasks.Serializers
{
    public interface IFileSerializer
    {
        T Serialize<T>(T item, string fileName);

        T Serialize<T>(T item, Stream stream);
    }
}
