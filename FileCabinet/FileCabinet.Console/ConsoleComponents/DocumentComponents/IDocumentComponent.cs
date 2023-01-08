using FileCabinet.Domain;

namespace FileCabinet.Console.ConsoleComponents.DocumentComponents
{
    public interface IDocumentComponent<T>
        where T : DocumentBase
    {
        void Show();
    }
}
