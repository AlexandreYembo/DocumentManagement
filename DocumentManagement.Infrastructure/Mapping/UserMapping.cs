using DocumentManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentManagement.Infrastructure.Mapping
{
    public class UserMapping
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.ToTable("USERAPP");
            builder.Property(t => t.Id).HasColumnName("IDUSERAPP");
            builder.Property(t => t.Login).HasColumnName("DSLOGIN");
        }
    }
}