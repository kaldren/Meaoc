using Microsoft.EntityFrameworkCore;

namespace Meaoc_API.Domain.Models
{
    public class MeaocContext : DbContext
    {
        public MeaocContext(DbContextOptions<MeaocContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordSalt)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(p => p.Content)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(p => p.AuthorId)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .Property(p => p.RecipientId)
                .IsRequired();

            modelBuilder.Entity<Message>()
                .HasOne(um => um.Author)
                .WithMany(m => m.SentMessages)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(um => um.Recipient)
                .WithMany(m => m.ReceivedMessages)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}