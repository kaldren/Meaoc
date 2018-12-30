using Microsoft.EntityFrameworkCore;

namespace Meaoc_API.Data.Models
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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}