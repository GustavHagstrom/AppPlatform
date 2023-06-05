using License.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicenseLibrary;
public class LicenseDbContext : DbContext
{
    public LicenseDbContext(DbContextOptions<LicenseDbContext> options) : base (options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AppLicense> Licenses { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Organization> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));

        modelBuilder.Entity<Organization>()
            .HasMany(o => o.Users)
            .WithOne(u => u.Organization)
            .HasForeignKey(u => u.OrganizationId);

        modelBuilder.Entity<Role>()
            .HasOne(r => r.Application)
            .WithMany(a => a.Roles)
            .HasForeignKey(r => r.ApplicationId);

        modelBuilder.Entity<AppLicense>()
            .HasOne(l => l.Application)
            .WithMany(a => a.Licenses)
            .HasForeignKey(l => l.ApplicationId);

        modelBuilder.Entity<AppLicense>()
            .HasOne(l => l.Organization)
            .WithMany(o => o.Licenses)
            .HasForeignKey(l => l.OrganizationId);

        base.OnModelCreating(modelBuilder);
    }
}
