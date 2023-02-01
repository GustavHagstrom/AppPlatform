using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServer.Models;

namespace IdentityServer.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Organization> Organizations { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
            .Property(x => x.Email)
            .IsRequired();
        builder.Entity<ApplicationUser>()
            .HasIndex(u => u.Email)
            .IsUnique();

        builder.Entity<Organization>()
            .Property(x => x.Name)
            .IsRequired();
        builder.Entity<Organization>()
            .Property(x => x.OrganizationNumber)
            .IsRequired();

        builder.Entity<ApplicationUser>()
            .HasOne(x => x.Orginization)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.OrginizationId)
            .IsRequired(false);
    }
}
