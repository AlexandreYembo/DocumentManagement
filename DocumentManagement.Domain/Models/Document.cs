using System;

namespace DocumentManagement.Domain.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FileNameStored { get; set; }
        public long Size { get; set; }
        public string Format { get; set; }
        public string ContentBase64 { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public long IdUser { get; set; }

        public virtual User User { get; set; }
    }
}