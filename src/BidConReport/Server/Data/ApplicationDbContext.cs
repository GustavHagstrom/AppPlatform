using BidConReport.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<EstimationImportSettings> EstimationImportSettings { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
