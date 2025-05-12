using Microsoft.EntityFrameworkCore;
using MyNewsApi.Models;

namespace MyNewsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; } // già presente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura la relazione 1 a n tra News e Category:
            modelBuilder.Entity<News>()
                .HasOne(n => n.Category)
                .WithMany(c => c.NewsItems)
                .HasForeignKey(n => n.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}