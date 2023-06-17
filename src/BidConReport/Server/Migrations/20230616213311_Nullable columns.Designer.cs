﻿// <auto-generated />
using System;
using BidConReport.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BidConReport.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230616213311_Nullable columns")]
    partial class Nullablecolumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BidConReport.Server.Shared.Enteties.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BidConReport.Server.Shared.Enteties.UserOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DefaultEstimationSettingsId")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DefaultEstimationSettingsId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrganizations");
                });

            modelBuilder.Entity("BidConReport.Shared.Entities.Estimation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BidConId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("CostBeforeChanges")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QuickTags")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("Representative")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SelectionTags")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("Supervisor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Estimations");
                });

            modelBuilder.Entity("BidConReport.Shared.Entities.EstimationImportSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CostBeforeChangesAccount")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CostFactorAccount")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HiddenTag")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("HiddenUnitTag")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NetCostAccount")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QuickTags")
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("SelectionTags")
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<bool>("UseRevisionAsSelectionTags")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("EstimationImportSettings");
                });

            modelBuilder.Entity("BidConReport.Shared.Entities.EstimationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ChangedToRowNumber")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DisplayedQuantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayedUnit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("EstimationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EstimationItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("RowNumber")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<double>("UnitCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EstimationId");

                    b.HasIndex("EstimationItemId");

                    b.ToTable("EstimationItem");
                });

            modelBuilder.Entity("BidConReport.Server.Shared.Enteties.UserOrganization", b =>
                {
                    b.HasOne("BidConReport.Shared.Entities.EstimationImportSettings", "DefaultEstimationSettings")
                        .WithMany()
                        .HasForeignKey("DefaultEstimationSettingsId");

                    b.HasOne("BidConReport.Server.Shared.Enteties.User", "User")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DefaultEstimationSettings");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BidConReport.Shared.Entities.EstimationItem", b =>
                {
                    b.HasOne("BidConReport.Shared.Entities.Estimation", null)
                        .WithMany("Items")
                        .HasForeignKey("EstimationId");

                    b.HasOne("BidConReport.Shared.Entities.EstimationItem", null)
                        .WithMany("Items")
                        .HasForeignKey("EstimationItemId");
                });

            modelBuilder.Entity("BidConReport.Server.Shared.Enteties.User", b =>
                {
                    b.Navigation("UserOrganizations");
                });

            modelBuilder.Entity("BidConReport.Shared.Entities.Estimation", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("BidConReport.Shared.Entities.EstimationItem", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
