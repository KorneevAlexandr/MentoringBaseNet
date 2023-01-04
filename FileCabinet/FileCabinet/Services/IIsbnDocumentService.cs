using FileCabinet.Domain;

namespace FileCabinet.Services
{
    public interface IIsbnDocumentService<T> : IDocumentService<T>
        where T : DocumentBase, IIsbn
    {
        IEnumerable<T> Search(string id = null, string title = null, string isbn = null);
    }
}
