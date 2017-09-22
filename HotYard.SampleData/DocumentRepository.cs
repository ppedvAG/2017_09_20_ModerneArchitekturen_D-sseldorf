using HotYard.Core.Models;
using HotYard.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotYard.SampleData
{
    public class DocumentRepository : IDocumentRepository
    {
        private IEnumerable<Document> _documents = new[]
        {
            new Document { Id = 1, Name = "Program", FileType = ".cs", Content = Encoding.UTF8.GetBytes("static void Main()") },
            new Document { Id = 2, Name = "Program", FileType = ".fs", Content = Encoding.UTF8.GetBytes("let main()") },
            new Document { Id = 3, Name = "Program", FileType = ".c", Content = Encoding.UTF8.GetBytes("int Main()") },
            new Document { Id = 4, Name = "Program", FileType = ".vb", Content = Encoding.UTF8.GetBytes("Sub Main()") },
            new Document { Id = 5, Name = "Document", FileType = ".cs", Content = Encoding.UTF8.GetBytes("public class Document : Entity") },
            new Document { Id = 6, Name = "Document", FileType = ".vb", Content = Encoding.UTF8.GetBytes("Public Class Document Inhertis Entity") },
        };

        public IEnumerable<Document> AllThatMatchName(string name) => _documents.Where(d => d.Name == name);
        public Document Get(int id) => _documents.SingleOrDefault(d => d.Id == id);
        public IEnumerable<Document> GetAll() => _documents;
    }
}