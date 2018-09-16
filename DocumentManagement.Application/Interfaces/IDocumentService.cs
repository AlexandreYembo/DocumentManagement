using System.Collections.Generic;
using DocumentManagement.Application.DTOs;
using DocumentManagement.Domain.Models;

namespace DocumentManagement.Application.Interfaces
{
    public interface IDocumentService
    {
        IEnumerable<DocumentDTO> List();
        void UpdateAccessDate(long id);
        void Delete(long id);
        long Create(Document document, string username);
    }
}   