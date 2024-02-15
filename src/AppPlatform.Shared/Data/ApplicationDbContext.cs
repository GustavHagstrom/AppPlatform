using AppPlatform.Core.Enteties;
using AppPlatform.Core.Enteties.EstimationView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppPlatform.Shared.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    private readonly ValueComparer<ICollection<string>> _stringCollectionValueComparer = new((c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

    public DbSet<BidconAccessCredentials> BidconAccessCredentials { get; set; }
    public DbSet<EstimationViewTemplate> EstimationViewTemplates { get; set; }
    public DbSet<UserSettings> UserSettings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
