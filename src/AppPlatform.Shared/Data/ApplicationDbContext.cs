using AppPlatform.Core.Enteties;
using AppPlatform.Core.Enteties.Authorization;
using AppPlatform.Core.Enteties.EstimationEnteties;
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
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleAccess> RoleAccess { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserAccess> UserAccess { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RoleAccess>()
            .HasKey(ra => new { ra.RoleId, ra.AccessClaimValue });
        modelBuilder.Entity<UserAccess>()
            .HasKey(ua => new { ua.UserId, ua.AccessClaimValue });
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<Estimation>()
            .HasOne(e => e.NetSheet)
            .WithOne(si => si.Estimation)
            .HasForeignKey<Estimation>(e => e.NetSheetId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<SheetItem>()
            .HasMany(si => si.Children)
            .WithOne(si => si.Parent)
            .HasForeignKey(si => si.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
