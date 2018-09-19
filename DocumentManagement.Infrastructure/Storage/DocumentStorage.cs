using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Domain.Models;
using DocumentManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DocumentManagement.Infrastructure.Storage
{
    public class DocumentStorage : IDocumentStorage
    {
        public string GetBase64(string fileNameStored)
        {
            var path = Path.Combine(AppContext.BaseDirectory, fileNameStored);

            if (File.Exists(path))
                return File.ReadAllText(path);
            return string.Empty;
        }

        public string Store(string name, string content)
        {
            var storageName = $"{name}{DateTime.Now.ToString("yyyyMMddHHmmss")}";

            var path = Path.Combine(AppContext.BaseDirectory, storageName);

            File.WriteAllText(path, content);

            return storageName;
        }

        public void Delete(string fileNameStored)
        {
            var path = Path.Combine(AppContext.BaseDirectory, fileNameStored);

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}