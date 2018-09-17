using DocumentManagement.Domain.Models;
using DocumentManagement.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagement.Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DocumentMapping());
            builder.ApplyConfiguration(new UserMapping());
        }
    }
}
