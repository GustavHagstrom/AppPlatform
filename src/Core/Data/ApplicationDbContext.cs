﻿using AppPlatform.Core.Enteties;
using AppPlatform.Core.Enteties.EstimationView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppPlatform.Core.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    private readonly ValueComparer<ICollection<string>> _stringCollectionValueComparer = new ((c1, c2) => c1!.SequenceEqual(c2!),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
 
    public DbSet<UserOrganization> UserOrganizations { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<BidconAccessCredentials> BidconAccessCredentials { get; set; }
    public DbSet<EstimationViewTemplate> EstimationViewTemplates { get; set; }
    public DbSet<OrganizationInvitaion> OrganizationInvitaions { get; set; }
    //public DbSet<Estimation> Estimations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserViewTemplate>()
            .HasOne(uvt => uvt.User)
            .WithMany(u => u.UserViewTemplates)
            .HasForeignKey(uvt => uvt.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserOrganization>()
            .HasKey(uo => new { uo.UserId, uo.OrganizationId });
    }
}