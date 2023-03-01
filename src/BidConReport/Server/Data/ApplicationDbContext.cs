﻿using BidConReport.Server.Features.Authorization.Models;
using BidConReport.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany();
        modelBuilder.Entity<Role>()
            .HasKey(r => r.Name);

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

        modelBuilder.Entity<EstimationImportSettings>()
            .Property(e => e.QuickTags)
            .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
            v => (JsonSerializer.Deserialize<ICollection<string>>(v, new JsonSerializerOptions())!))
            .HasColumnType("NVARCHAR(1000)")
            .Metadata.SetValueComparer(_stringCollectionValueComparer);
        modelBuilder.Entity<EstimationImportSettings>()
            .Property(e => e.SelectionTags)
            .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
            v => (JsonSerializer.Deserialize<ICollection<string>>(v, new JsonSerializerOptions())!))
            .HasColumnType("NVARCHAR(1000)")
            .Metadata.SetValueComparer(_stringCollectionValueComparer);
    }

    
}
