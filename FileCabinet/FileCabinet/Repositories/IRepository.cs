using FileCabinet.Domain;

namespace FileCabinet.Repositories
{
    public interface IRepository<T>
        where T : DocumentBase
    {
        IEnumerable<T> GetAll();

        T GetById(string id);

        string Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
