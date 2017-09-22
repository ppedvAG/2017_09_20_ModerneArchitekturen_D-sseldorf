using HotYard.Core.Models;
using System.Collections.Generic;

namespace HotYard.Core.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        IEnumerable<Document> AllThatMatchName(string name);
    }
}
