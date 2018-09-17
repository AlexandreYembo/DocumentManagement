using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Domain.Models;
using DocumentManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentManagement.Infrastructure.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DatabaseContext _dbContext;

        public DocumentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Create(Document document)
        {
            _dbContext.Documents.Add(document);
            _dbContext.SaveChanges();

            return document.Id;
        }

        public void Delete(long id)
        {
            var document = _dbContext.Documents.FirstOrDefault(d => d.Id == id);
            if (document != null)
            {
                _dbContext.Documents.Remove(document);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Document> List() =>
            _dbContext.Documents.AsNoTracking().OrderByDescending(d => d.LastAccessDate).ToList();

        public void UpdateAccessDate(long id)
        {
            var document = _dbContext.Documents.FirstOrDefault(d => d.Id == id);
            if (document != null)
            {
                document.LastAccessDate = DateTime.Now;
                _dbContext.Documents.Update(document);
                _dbContext.SaveChanges();
            }
        }
    }
}
