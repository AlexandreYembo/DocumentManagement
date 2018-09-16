using DocumentManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentManagement.Infrastructure.Mapping
{
    public class DocumentMapping
        : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.ToTable("DOCUMENT");
            builder.Property(t => t.Id).HasColumnName("IDDOCUMENT");
            builder.Property(t => t.Name).HasColumnName("FILENAME");
            builder.Property(t => t.Size).HasColumnName("FILESIZE");
            builder.Property(t => t.Format).HasColumnName("FILEFORMAT");
            builder.Property(t => t.UploadDate).HasColumnName("UPLOADDATE");
            builder.Property(t => t.UpdateDate).HasColumnName("UPDATEDATE");
            builder.Property(t => t.LastAccessDate).HasColumnName("LASTACCESSDATE");
            builder.Property(t => t.FileNameStored).HasColumnName("FILENAMESTORAGE");
        }
    }
}