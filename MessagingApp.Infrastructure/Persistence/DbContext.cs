using Microsoft.EntityFrameworkCore;
using MessagingApp.Domain.Entities;

namespace MessagingApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Nickname);
                entity.Property(u => u.Nickname).HasMaxLength(50).IsRequired();
                entity.Property(u => u.PublicKey).IsRequired();
            });
        }
    }
}
