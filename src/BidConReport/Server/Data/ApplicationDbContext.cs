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
        modelBuilder.Entity<ReportTemplate>()
            .HasOne(x => x.TopLeftHeader)
            .WithOne()
            .HasForeignKey<ReportTemplate>(x => x.TopLeftHeaderId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ReportTemplate>()
            .HasOne(x => x.TopRightHeader)
            .WithOne()
            .HasForeignKey<ReportTemplate>(x => x.TopRightHeaderId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ReportTemplate>()
            .HasOne(x => x.TitleSection)
            .WithOne()
            .HasForeignKey<ReportTemplate>(x => x.TitleSectionId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ReportTemplate>()
            .HasOne(x => x.InformationSection)
            .WithOne()
            .HasForeignKey<ReportTemplate>(x => x.InformationSectionId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ReportTemplate>()
            .HasOne(x => x.PriceSection)
            .WithOne()
            .HasForeignKey<ReportTemplate>(x => x.PriceSectionId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ReportTemplate>()
           .HasOne(x => x.TableSection)
           .WithOne()
           .HasForeignKey<ReportTemplate>(x => x.TableSectionId)
           .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<HeaderDefinition>()
           .HasOne(x => x.Font)
           .WithOne()
           .HasForeignKey<HeaderDefinition>(x => x.FontId)
           .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<TitleSection>()
           .HasOne(x => x.Font)
           .WithOne()
           .HasForeignKey<TitleSection>(x => x.FontId)
           .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<InformationItem>()
            .HasOne<InformationSection>()
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.InformationSectionId)
           .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<InformationSection>()
           .HasOne(x => x.TitleFont)
           .WithOne()
           .HasForeignKey<InformationSection>(x => x.TitleFontId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<InformationSection>()
           .HasOne(x => x.ValueFont)
           .WithOne()
           .HasForeignKey<InformationSection>(x => x.ValueFontId)
           .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<PriceSection>()
           .HasOne(x => x.PriceFont)
           .WithOne()
           .HasForeignKey<PriceSection>(x => x.PriceFontId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<PriceSection>()
           .HasOne(x => x.CommentFont)
           .WithOne()
           .HasForeignKey<PriceSection>(x => x.CommentFontId)
           .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<ColumnDefinition>()
            .HasOne<TableSection>()
            .WithMany(x => x.Columns)
            .HasForeignKey(x => x.TableSectionId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ColumnDefinition>()
           .HasOne(x => x.GroupFont)
           .WithOne()
           .HasForeignKey<ColumnDefinition>(x => x.GroupFontId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ColumnDefinition>()
           .HasOne(x => x.PartFont)
           .WithOne()
           .HasForeignKey<ColumnDefinition>(x => x.PartFontId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<ColumnDefinition>()
           .HasOne(x => x.CellFont)
           .WithOne()
           .HasForeignKey<ColumnDefinition>(x => x.CelleFontId)
           .OnDelete(DeleteBehavior.ClientSetNull);

    }


}
