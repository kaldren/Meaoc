using Meaoc_API.Helpers;
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
            modelBuilder.Entity<User>().HasData(new User
            {
                Email = "drenski666@gmail.com",
                FirstName = "Kaloyan",
                LastName = "Drenski",
                Id = 1,
                Username = "kdrenski"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Email = "bill@microsoft.com",
                FirstName = "Bill",
                LastName = "Gates",
                Id = 2,
                Username = "bill"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Email = "elon@tesla.com",
                FirstName = "Elon",
                LastName = "Musk",
                Id = 3,
                Username = "elon"
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                Id = 1,
                Content = "Hello there, how are you today?",
                AuthorId = 1,
                RecipientId = 2,
                IsRead = false
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                Id = 2,
                Content = "Wait for me. I will be ready in 10 minutes.",
                AuthorId = 3,
                RecipientId = 1,
                IsRead = false
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                Id = 3,
                Content = "It was a pleasure seeing you!",
                AuthorId = 2,
                RecipientId = 3,
                IsRead = false
            });

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