using Microsoft.EntityFrameworkCore;

namespace MultiplaDatabaseConnection.Data;

public class PostgresContext: DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options): base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Product>().Property(x => x.UnitPrice).IsRequired().HasPrecision(18, 4);

    }
}