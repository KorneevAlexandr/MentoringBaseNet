using FileCabinet.Domain;
using FileCabinet.Repositories;

namespace FileCabinet.Services
{
    public class IsbnDocumentService<T> : DocumentService<T>, IIsbnDocumentService<T>
        where T : DocumentBase, IIsbn
    {
        public IsbnDocumentService(IRepository<T> repository)
            : base(repository)
        { }

        public IEnumerable<T> Search(string id = null, string title = null, string isbn = null)
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

            if (isbn is not null)
            {
                query = query.Where(x => x.Isbn.Contains(isbn));
            }

            return query.ToList();
        }
    }
}
