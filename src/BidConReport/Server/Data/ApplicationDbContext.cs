using BidConReport.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<EstimationImportSettings> EstimationImportSettings { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
