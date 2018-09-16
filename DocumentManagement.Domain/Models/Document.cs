using System;

namespace DocumentManagement.Domain.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Format { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime LastAccessDate { get; set; }
    }
}