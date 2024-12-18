﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using AppPlatform.Shared.Data;

#nullable disable

namespace AppPlatform.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240105081613_SubscriptionFlattening")]
    partial class SubscriptionFlattening
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Server.Enteties.BidconAccessCredentials", b =>
                {
                    b.Property<string>("OrganizationId")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("Database")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("DesktopPort")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("ServerAuthentication")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UseDesktopBidconLink")
                        .HasColumnType("INTEGER");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("OrganizationId");

                    b.ToTable("BidconAccessCredentials");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.CellFormat", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Align")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Bold")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BorderBottom")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BorderLeft")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BorderRight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BorderStyle")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BorderTop")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CellTemplateId")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("DecimalCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FontFamily")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("FontSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormatType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IncludeTimeOfDay")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Italic")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Justify")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SheetColumnId")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<bool>("ThoasandsSeparator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Underline")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CellTemplateId")
                        .IsUnique();

                    b.HasIndex("SheetColumnId")
                        .IsUnique();

                    b.ToTable("CellFormat");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Column")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataSectionTemplateId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Row")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DataSectionTemplateId");

                    b.ToTable("CellTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.DataColumn", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("DataSectionTemplateId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WidthPercent")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DataSectionTemplateId");

                    b.ToTable("DataColumn");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("EstimationViewTemplateId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RowCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.ToTable("DataSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("EstimationViewTemplates");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.HeaderOrFooter", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("EstimationViewTemplateId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.ToTable("HeaderOrFooter");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("ColumnType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NetSheetSectionTemplateId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WidthPercent")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NetSheetSectionTemplateId");

                    b.ToTable("SheetColumn");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetSectionTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("EstimationViewTemplateId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SheetType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.ToTable("SheetSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.Organization", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserLimit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Server.Enteties.OrganizationInvitaion", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationInvitaion");
                });

            modelBuilder.Entity("Server.Enteties.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActiveOrganizationId")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActiveOrganizationId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Server.Enteties.UserOrganization", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizationId")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "OrganizationId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("UserOrganizations");
                });

            modelBuilder.Entity("Server.Enteties.UserViewTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("EstimationViewTemplateId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserViewTemplate");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Server.Enteties.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Server.Enteties.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Enteties.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Server.Enteties.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Server.Enteties.BidconAccessCredentials", b =>
                {
                    b.HasOne("Server.Enteties.Organization", "Organization")
                        .WithOne("BidconCredentials")
                        .HasForeignKey("Server.Enteties.BidconAccessCredentials", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.CellFormat", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.CellTemplate", "CellTemplate")
                        .WithOne("Format")
                        .HasForeignKey("Server.Enteties.EstimationView.CellFormat", "CellTemplateId");

                    b.HasOne("Server.Enteties.EstimationView.SheetColumn", "SheetColumn")
                        .WithOne("CellFormat")
                        .HasForeignKey("Server.Enteties.EstimationView.CellFormat", "SheetColumnId");

                    b.Navigation("CellTemplate");

                    b.Navigation("SheetColumn");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.DataSectionTemplate", "DataSectionTemplate")
                        .WithMany("Cells")
                        .HasForeignKey("DataSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.DataColumn", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.DataSectionTemplate", "DataSectionTemplate")
                        .WithMany("Columns")
                        .HasForeignKey("DataSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationView")
                        .WithMany("DataSections")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationView");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.HasOne("Server.Enteties.Organization", "Organization")
                        .WithMany("EstimationViewTemplates")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.HeaderOrFooter", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany("HeaderOrFooters")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.SheetSectionTemplate", "NetSheetSectionTemplate")
                        .WithMany("Columns")
                        .HasForeignKey("NetSheetSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NetSheetSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetSectionTemplate", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany("SheetSections")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");
                });

            modelBuilder.Entity("Server.Enteties.OrganizationInvitaion", b =>
                {
                    b.HasOne("Server.Enteties.Organization", "Organization")
                        .WithMany("OrganizationInvitaions")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Server.Enteties.User", b =>
                {
                    b.HasOne("Server.Enteties.Organization", "ActiveOrganization")
                        .WithMany()
                        .HasForeignKey("ActiveOrganizationId");

                    b.Navigation("ActiveOrganization");
                });

            modelBuilder.Entity("Server.Enteties.UserOrganization", b =>
                {
                    b.HasOne("Server.Enteties.Organization", "Organization")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Enteties.User", "User")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.Enteties.UserViewTemplate", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany()
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Enteties.User", "User")
                        .WithMany("UserViewTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.Navigation("Format")
                        .IsRequired();
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.Navigation("Cells");

                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.Navigation("DataSections");

                    b.Navigation("HeaderOrFooters");

                    b.Navigation("SheetSections");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.Navigation("CellFormat")
                        .IsRequired();
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetSectionTemplate", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Server.Enteties.Organization", b =>
                {
                    b.Navigation("BidconCredentials");

                    b.Navigation("EstimationViewTemplates");

                    b.Navigation("OrganizationInvitaions");

                    b.Navigation("UserOrganizations");
                });

            modelBuilder.Entity("Server.Enteties.User", b =>
                {
                    b.Navigation("UserOrganizations");

                    b.Navigation("UserViewTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
