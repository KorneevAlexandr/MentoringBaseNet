using FileCabinet.Domain;

namespace FileCabinet.Console.ConsoleComponents.DocumentComponents
{
    public interface IIsbnDocumentComponent<T> : IDocumentComponent<T>
        where T : DocumentBase, IIsbn
    {
    }
}
