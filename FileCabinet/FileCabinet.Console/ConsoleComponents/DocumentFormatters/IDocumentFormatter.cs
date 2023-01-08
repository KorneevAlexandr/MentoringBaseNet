namespace FileCabinet.Console.ConsoleComponents.DocumentFormatters
{
    public interface IDocumentFormatter<T>
    {
        T Read();

        void Write(T value);
    }
}
