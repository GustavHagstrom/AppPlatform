﻿// <auto-generated />
using System;
using LicenseLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace License.Api.Migrations
{
    [DbContext(typeof(LicenseDbContext))]
    [Migration("20230612144139_Multiple licenses per user")]
    partial class Multiplelicensesperuser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppLicenseUser", b =>
                {
                    b.Property<int>("LicensesId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LicensesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserLicenses", (string)null);
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.AppLicense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationName");

                    b.HasIndex("OrganizationName");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.Application", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Name");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.Organization", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Name");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationName");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrganizationUser", b =>
                {
                    b.Property<string>("OrganizationsName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrganizationsName", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserOrganizations", (string)null);
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("AppLicenseUser", b =>
                {
                    b.HasOne("License.Api.Shared.Enteties.AppLicense", null)
                        .WithMany()
                        .HasForeignKey("LicensesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("License.Api.Shared.Enteties.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.AppLicense", b =>
                {
                    b.HasOne("License.Api.Shared.Enteties.Application", "Application")
                        .WithMany("Licenses")
                        .HasForeignKey("ApplicationName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("License.Api.Shared.Enteties.Organization", "Organization")
                        .WithMany("Licenses")
                        .HasForeignKey("OrganizationName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.Role", b =>
                {
                    b.HasOne("License.Api.Shared.Enteties.Application", "Application")
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("OrganizationUser", b =>
                {
                    b.HasOne("License.Api.Shared.Enteties.Organization", null)
                        .WithMany()
                        .HasForeignKey("OrganizationsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("License.Api.Shared.Enteties.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("License.Api.Shared.Enteties.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("License.Api.Shared.Enteties.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.Application", b =>
                {
                    b.Navigation("Licenses");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("License.Api.Shared.Enteties.Organization", b =>
                {
                    b.Navigation("Licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
