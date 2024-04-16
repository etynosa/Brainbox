using BrainboxApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace BrainboxApi.Data
{
    public class BrainboxDbContext : DbContext
    {
        public BrainboxDbContext(DbContextOptions<BrainboxDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
