using DocumentManagement.Application.DTOs;
using DocumentManagement.Domain.Models;
using System.Collections.Generic;

namespace DocumentManagement.Tests.Stubs
{
    public static class DocumentSub
    {
        public static DocumentDTO SimpleDocument = new DocumentDTO()
        {
            Id = 1,
            Name = "Default",
            Format = "csv",
            Size = 100,
            ContentBase64 = "abcabcabcabcabcabcabcabcabcabc"
        };

        public static List<Document> ListDocument = new List<Document>()
        {
            new Document
            {
                Id = 1,
                Name = "Default",
                Format = "csv",
                Size = 100,
                ContentBase64 = "abcabcabcabcabcabcabcabcabcabc"
            },
            new Document
            {
                Id = 2,
                Name = "Default2",
                Format = "csv",
                Size = 200,
                ContentBase64 = "abcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcabcab"
            }
        };
    }
}
