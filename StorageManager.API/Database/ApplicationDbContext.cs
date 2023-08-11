using Microsoft.EntityFrameworkCore;
using StorageManager.API.Entities;

namespace StorageManager.API.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
            .Property(p => p.Title);

        modelBuilder.Entity<Product>()
            .Property(p => p.Description);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price);

        modelBuilder.Entity<Product>()
            .Property(p => p.SKU);

        modelBuilder.Entity<Product>()
            .Property(p => p.CreatedOnUtc)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
