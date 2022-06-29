using Microsoft.EntityFrameworkCore;
using stazDAL.Entities;

namespace stazDAL
{
    public class StazDbContext : DbContext
    {
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }

        public StazDbContext(DbContextOptions<StazDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Author>()
                .Property(a => a.SurName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
