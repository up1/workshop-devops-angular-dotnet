using api.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            Enumerable.Range(1, 100).Select(i => new Product
            {
                Id = i,
                Name = $"Product {i}",
                Price = Math.Round(9.99 + i * 1.5, 2),
                Image = $"https://picsum.photos/seed/product{i}/200/200"
            }).ToArray()
        );
    }
}
