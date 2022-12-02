using ForumsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumsService.Infrastructure.Contexts
{
    public class ForumDbReadOnlyContext : DbContext
    {
        public ForumDbReadOnlyContext(DbContextOptions<ForumDbReadOnlyContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForumDto>().ToTable("Forums");
        }

        public DbSet<ForumDto> Forums { get; set; }
    }
}