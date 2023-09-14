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
    public DbSet<Role> Roles { get; set; }
    public DbSet<BidconCredentials> BidconCredentials { get; set; }
    public DbSet<EstimationViewTemplate> EstimationViewTemplates { get; set; }
    //public DbSet<ExplicitEstimationViewAccess> ExplicitEstimationViewTemplates { get; set; }
    //public DbSet<Estimation> Estimations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        //modelBuilder.Entity<ExplicitEstimationViewAccess>()
        //    .HasOne(e => e.Estimation)
        //    .WithMany()
        //    .HasForeignKey(e => e.EstimationId)
        //    .OnDelete(DeleteBehavior.Cascade); // Set cascade delete for this relationship

        //modelBuilder.Entity<ExplicitEstimationViewAccess>()
        //    .HasOne(e => e.User)
        //    .WithMany()
        //    .HasForeignKey(e => e.UserId)
        //    .OnDelete(DeleteBehavior.Cascade); // Set restrict delete for this relationship (or use DeleteBehavior.SetNull if applicable)

        //modelBuilder.Entity<ExplicitEstimationViewAccess>()
        //    .HasOne(e => e.EstimationViewTemplate)
        //    .WithMany()
        //    .HasForeignKey(e => e.EstimationViewTemplateId)
        //    .OnDelete(DeleteBehavior.Cascade); // Set cascade delete for this relationship


        // Configure the many-to-many relationship with cascade delete
        //modelBuilder.Entity<User>()
        //    .HasMany(u => u.Roles)
        //    .WithMany(r => r.Users)
        //    .UsingEntity<UserRole>(
        //        ur => ur.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Cascade),
        //        ur => ur.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
        //        ur =>
        //        {
        //            ur.HasKey("UserId", "RoleId");
        //            ur.ToTable("UserRole");
        //        });

        //Suppress the warning about cascade paths

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany()
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany()
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
