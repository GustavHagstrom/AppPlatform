using BidConReport.Server.Shared.Enteties;
using BidConReport.Shared.Entities;
using BidConReport.Shared.Features.ReportTemplate;
using BidConReport.Shared.Features.ReportTemplate.Header;
using BidConReport.Shared.Features.ReportTemplate.Information;
using BidConReport.Shared.Features.ReportTemplate.Price;
using BidConReport.Shared.Features.ReportTemplate.Table;
using BidConReport.Shared.Features.ReportTemplate.Title;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace BidConReport.Server.Data;

public class ApplicationDbContext : DbContext
{
    private readonly ValueComparer<ICollection<string>> _stringCollectionValueComparer = new ((c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<EstimationImportSettings> EstimationImportSettings { get; set; }
    public DbSet<Estimation> Estimations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOrganization> UserOrganizations { get; set; }
    public DbSet<ReportTemplate> ReportTemplates { get; set; }
    public DbSet<FontFamily> FontFamilies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        MapUserAndOrganizations(modelBuilder);
        MapEstimation(modelBuilder);
        MapImportSettings(modelBuilder);
        MapReportTemplate(modelBuilder);

    }
    private void MapUserAndOrganizations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserOrganization>()
            .HasOne(u => u.User)
            .WithMany(u => u.UserOrganizations)
            .HasForeignKey(u => u.UserId);
    }
    private void MapEstimation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estimation>()
            .Property(e => e.QuickTags)
            .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
            v => (JsonSerializer.Deserialize<ICollection<string>>(v, new JsonSerializerOptions())!))
            .HasColumnType("NVARCHAR(1000)")
            .Metadata.SetValueComparer(_stringCollectionValueComparer);
        modelBuilder.Entity<Estimation>()
            .Property(e => e.SelectionTags)
            .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
            v => (JsonSerializer.Deserialize<ICollection<string>>(v, new JsonSerializerOptions())!))
            .HasColumnType("NVARCHAR(1000)")
            .Metadata.SetValueComparer(_stringCollectionValueComparer);

        modelBuilder.Entity<EstimationItem>()
            .Property(e => e.Tags)
            .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
            v => (JsonSerializer.Deserialize<ICollection<string>>(v, new JsonSerializerOptions())!))
            .HasColumnType("NVARCHAR(1000)")
            .Metadata.SetValueComparer(_stringCollectionValueComparer);
    }
    private void MapImportSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstimationImportSettings>()
           .Property(e => e.QuickTags)
           .HasConversion(
               v => string.Join(",", v),
               v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
           .HasColumnType("NVARCHAR(1000)")
           .Metadata.SetValueComparer(_stringCollectionValueComparer);
        modelBuilder.Entity<EstimationImportSettings>()
            .Property(e => e.SelectionTags)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
            .HasColumnType("NVARCHAR(1000)")
            .Metadata.SetValueComparer(_stringCollectionValueComparer);
    }
    private void MapReportTemplate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FontProperties>()
            .HasMany<InformationSection>()
            .WithOne(x => x.ValueFont)
            .HasForeignKey(x => x.ValueFontId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FontProperties>()
            .HasMany<InformationSection>()
            .WithOne(x => x.TitleFont)
            .HasForeignKey(x => x.TitleFontId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<FontProperties>()
            .HasMany<HeaderDefinition>()
            .WithOne(x => x.Font)
            .HasForeignKey(x => x.FontId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<FontProperties>()
            .HasMany<TableSection>()
            .WithOne(x => x.CellFont)
            .HasForeignKey(x => x.CellFontId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FontProperties>()
            .HasMany<TableSection>()
            .WithOne(x => x.PartFont)
            .HasForeignKey(x => x.PartFontId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FontProperties>()
            .HasMany<TableSection>()
            .WithOne(x => x.GroupFont)
            .HasForeignKey(x => x.GroupFontId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<FontProperties>()
            .HasMany<PriceSection>()
            .WithOne(x => x.CommentFont)
            .HasForeignKey(x => x.CommentFontId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<FontProperties>()
            .HasMany<PriceSection>()
            .WithOne(x => x.PriceFont)
            .HasForeignKey(x => x.PriceFontId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<HeaderDefinition>()
            .HasMany<ReportTemplate>()
            .WithOne(x => x.TopLeftHeader)
            .HasForeignKey(x => x.TopLeftHeaderId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<HeaderDefinition>()
            .HasMany<ReportTemplate>()
            .WithOne(x => x.TopRightHeader)
            .HasForeignKey(x => x.TopRightHeaderId)
            .OnDelete(DeleteBehavior.NoAction);

    }


}
