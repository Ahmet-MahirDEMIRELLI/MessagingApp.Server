﻿using Microsoft.EntityFrameworkCore;
using MessagingApp.Domain.Entities;

namespace MessagingApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Message> Messages => Set<Message>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Nickname);
                entity.Property(u => u.Nickname).HasMaxLength(50).IsRequired();
                entity.Property(u => u.X25519PublicKey).IsRequired();
                entity.Property(u => u.Ed25519PublicKey).IsRequired();
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(m => m.MessageId);
                entity.Property(m => m.Sender);
                entity.Property(m => m.Receiver).IsRequired();
                entity.Property(m => m.Content).IsRequired();
                entity.Property(m => m.Timestamp).IsRequired();
            });
        }
    }
}
