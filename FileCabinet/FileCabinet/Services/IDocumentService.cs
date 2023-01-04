using FileCabinet.Domain;

namespace FileCabinet.Services
{
    public interface IDocumentService<T>
        where T : DocumentBase
    {
        IEnumerable<T> Search(string id = null, string title = null);

        IEnumerable<T> GetAll();

        T GetById(string id);

        string Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(string id);
    }
}
