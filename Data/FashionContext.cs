using System;
using Microsoft.EntityFrameworkCore;
using Fashioninventorysystem.Models;

public class FashionContext : DbContext
{
    public FashionContext(DbContextOptions<FashionContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        base.OnModelCreating(modelBuilder);
    }
}
