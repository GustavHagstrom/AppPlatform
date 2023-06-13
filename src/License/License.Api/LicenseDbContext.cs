using License.Api.Shared.Enteties;
using Microsoft.EntityFrameworkCore;

namespace LicenseLibrary;
public class LicenseDbContext : DbContext
{
    public LicenseDbContext(DbContextOptions<LicenseDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AppLicense> Licenses { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Organization> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));
        modelBuilder.Entity<User>()
            .HasMany(u => u.Licenses)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserLicenses"));
        modelBuilder.Entity<User>()
            .HasMany(u => u.Organizations)
            .WithMany(o => o.Users)
            .UsingEntity(j => j.ToTable("UserOrganizations"));
        modelBuilder.Entity<User>()
            .HasOne(u => u.CurrentOrganization)
            .WithMany()
            .HasForeignKey(u => u.CurrentOrganizationName);

        modelBuilder.Entity<AppLicense>()
            .HasOne(l => l.Application)
            .WithMany(a => a.Licenses)
            .HasForeignKey(l => l.ApplicationName);
        modelBuilder.Entity<AppLicense>()
            .HasOne(l => l.Organization)
            .WithMany(o => o.Licenses)
            .HasForeignKey(l => l.OrganizationName)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Role>()
            .HasOne(r => r.Application)
            .WithMany(a => a.Roles)
            .HasForeignKey(r => r.ApplicationName)
            .OnDelete(DeleteBehavior.NoAction);        
    }
}
