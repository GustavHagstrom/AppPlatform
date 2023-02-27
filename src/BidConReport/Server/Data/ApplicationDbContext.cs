using BidConReport.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<EstimationImportSettings> EstimationImportSettings { get; set; }
    public DbSet<Estimation> Estimations { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //if (!optionsBuilder.IsConfigured)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory())
        //       .AddJsonFile("appsettings.json")
        //       .Build();
        //    var connectionString = configuration.GetConnectionString("Default");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EstimationImportSettings>()
            .HasMany(s => s.QuickTags)
            .WithMany()
            .UsingEntity(j => j.ToTable("SettingQuickTags"));
        modelBuilder.Entity<EstimationImportSettings>()
            .HasMany(s => s.SelectionTags)
            .WithMany()
            .UsingEntity(j => j.ToTable("SettingSelectionTags"));

        modelBuilder.Entity<Estimation>()
            .HasMany(s => s.QuickTags)
            .WithMany()
            .UsingEntity(j => j.ToTable("EstimationQuickTags"));
        modelBuilder.Entity<Estimation>()
            .HasMany(s => s.SelectionTags)
            .WithMany()
            .UsingEntity(j => j.ToTable("EstimationSelectionTags"));
        modelBuilder.Entity<Estimation>()
            .HasMany(e => e.Items)
            .WithOne();

        modelBuilder.Entity<EstimationItem>()
            .HasMany(e => e.Items)
            .WithOne();
        modelBuilder.Entity<EstimationItem>()
            .HasMany(s => s.QuickTags)
            .WithMany()
            .UsingEntity(j => j.ToTable("EstimationItemQuickTags"));
        modelBuilder.Entity<EstimationItem>()
            .HasMany(s => s.SelectionTags)
            .WithMany()
            .UsingEntity(j => j.ToTable("EstimationItemSelectionTags"));
    }
}
