﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManagement.Application.DTOs
{
    public class DocumentDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Format { get; set; }
        public string ContentBase64 { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime LastAccessDate { get; set; }
    }
}
