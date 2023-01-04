using FileCabinet.Domain;
using FileCabinet.Repositories;

namespace FileCabinet.Services
{
    public class DocumentService<T> : IDocumentService<T>
        where T : DocumentBase
    {
        protected readonly IRepository<T> _repository;

        // TODO: caching

        public DocumentService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> Search(string id = null, string title = null)
        {
            var query = GetAll();

            if (id is not null)
            {
                query = query.Where(x => x.Id.Contains(id));
            }

            if (title is not null)
            {
                query = query.Where(x => x.Title.Contains(title));
            }

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(string id)
        {
            return _repository.GetById(id);
        }

        public string Create(T entity)
        {
            return _repository.Create(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }
    }
}
