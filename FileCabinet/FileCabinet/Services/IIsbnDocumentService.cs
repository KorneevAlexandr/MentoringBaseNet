using FileCabinet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinet.Services
{
    public interface IIsbnDocumentService<T> : IDocumentService<T>
        where T : DocumentBase, IIsbn
    {
        IEnumerable<T> Search(string id = null, string title = null, string isbn = null);
    }
}
