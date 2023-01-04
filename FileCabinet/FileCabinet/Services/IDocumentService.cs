using FileCabinet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinet.Services
{
    internal interface IDocumentService<T>
        where T : DocumentBase
    {
    }
}
