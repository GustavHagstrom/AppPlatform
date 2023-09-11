using BidConReport.Server.Enteties;
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
    public DbSet<BidconCredentials> BidconCredentials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        MapUserAndOrganizations(modelBuilder);

    }
    private void MapUserAndOrganizations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>()
            .HasMany(u => u.Users)
            .WithOne(u => u.Organization)
            .HasForeignKey(u => u.OrganizationId);
    }
}
