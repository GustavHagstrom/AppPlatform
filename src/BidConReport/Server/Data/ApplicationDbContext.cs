using BidConReport.Server.Enteties;
using BidConReport.Server.Enteties.EstimationView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BidConReport.Server.Data;

public class ApplicationDbContext : DbContext
{
    private readonly ValueComparer<ICollection<string>> _stringCollectionValueComparer = new ((c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<BidconCredentials> BidconCredentials { get; set; }
    public DbSet<EstimationViewTemplate> EstimationViewTemplates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<License>()
            .HasMany(l => l.Users)
            .WithOne(u => u.License)
            .HasForeignKey(u => u.LicenseId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
