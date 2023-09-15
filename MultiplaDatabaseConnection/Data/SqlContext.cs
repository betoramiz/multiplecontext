using Microsoft.EntityFrameworkCore;

namespace MultiplaDatabaseConnection.Data;

public class SqlContext: DbContext
{
    
    public SqlContext(DbContextOptions<SqlContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasKey(x => x.Id);
        modelBuilder.Entity<Client>().Property(x => x.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Client>().Property(x => x.ClientSince).IsRequired().HasDefaultValue(DateTime.Today);
    }
}