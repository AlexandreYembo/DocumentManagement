using DocumentManagement.Domain.Models;
using System.Collections.Generic;

namespace DocumentManagement.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        void UpdateAccessDate(long id);
        IEnumerable<Document> List();
        void Delete(Document document);
        long Create(Document document);
        Document GetById(long id);
    }
}
