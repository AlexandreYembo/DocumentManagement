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
            var path = Path.Combine(AppContext.BaseDirectory, "files", fileNameStored);

            if (File.Exists(path))
            {
                Byte[] bytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(bytes);
            }
            return string.Empty;
        }

        public string Store(string name, string content)
        {
            var storageName = $"{name}{DateTime.Now.ToString("yyyyMMddHHmmss")}";

            var path = Path.Combine(AppContext.BaseDirectory, "files");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.WriteAllBytes(path, Convert.FromBase64String(content));

            return storageName;
        }
    }
}