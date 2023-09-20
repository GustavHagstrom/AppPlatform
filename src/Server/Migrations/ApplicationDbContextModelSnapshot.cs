﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Server.Enteties.BidconAccessCredentials", b =>
                {
                    b.Property<string>("OrganizationId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Database")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DesktopPort")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Server")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ServerAuthentication")
                        .HasColumnType("bit");

                    b.Property<bool>("UseDesktopBidconLink")
                        .HasColumnType("bit");

                    b.Property<string>("User")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrganizationId");

                    b.ToTable("BidconAccessCredentials");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.CellFormat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Align")
                        .HasColumnType("int");

                    b.Property<bool>("Bold")
                        .HasColumnType("bit");

                    b.Property<bool>("BorderBottom")
                        .HasColumnType("bit");

                    b.Property<bool>("BorderLeft")
                        .HasColumnType("bit");

                    b.Property<bool>("BorderRight")
                        .HasColumnType("bit");

                    b.Property<bool>("BorderTop")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CellTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DecimalCount")
                        .HasColumnType("int");

                    b.Property<string>("FontFamily")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FontSize")
                        .HasColumnType("int");

                    b.Property<int>("FormatType")
                        .HasColumnType("int");

                    b.Property<bool>("IncludeTimeOfDay")
                        .HasColumnType("bit");

                    b.Property<bool>("Italic")
                        .HasColumnType("bit");

                    b.Property<int>("Justify")
                        .HasColumnType("int");

                    b.Property<Guid?>("SheetColumnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Style")
                        .HasColumnType("int");

                    b.Property<bool>("ThoasandsSeparator")
                        .HasColumnType("bit");

                    b.Property<bool>("Underline")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CellTemplateId")
                        .IsUnique()
                        .HasFilter("[CellTemplateId] IS NOT NULL");

                    b.HasIndex("SheetColumnId")
                        .IsUnique()
                        .HasFilter("[SheetColumnId] IS NOT NULL");

                    b.ToTable("CellFormat");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<Guid>("DataSectionTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DataSectionTemplateId");

                    b.ToTable("CellTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.DataColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataSectionTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("WidthPercent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DataSectionTemplateId");

                    b.ToTable("DataColumn");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstimationViewTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("RowCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.ToTable("DataSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("EstimationViewTemplates");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.HeaderOrFooter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstimationViewTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.ToTable("HeaderOrFooter");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.NetSheetSectionTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstimationViewTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId")
                        .IsUnique();

                    b.ToTable("NetSheetSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ColumnType")
                        .HasColumnType("int");

                    b.Property<Guid>("NetSheetSectionTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("WidthPercent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NetSheetSectionTemplateId");

                    b.ToTable("SheetColumn");
                });

            modelBuilder.Entity("Server.Enteties.License", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId")
                        .IsUnique();

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Server.Enteties.Organization", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Server.Enteties.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Server.Enteties.RoleRight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Right")
                        .HasColumnType("int");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRight");
                });

            modelBuilder.Entity("Server.Enteties.RoleViewTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstimationViewTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleViewTemplate");
                });

            modelBuilder.Entity("Server.Enteties.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LicenseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Enteties.UserRight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Right")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRight");
                });

            modelBuilder.Entity("Server.Enteties.UserViewTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstimationViewTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstimationViewTemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserViewTemplate");
                });

            modelBuilder.Entity("Server.Enteties.BidconAccessCredentials", b =>
                {
                    b.HasOne("Server.Enteties.Organization", null)
                        .WithOne("BidconCredentials")
                        .HasForeignKey("Server.Enteties.BidconAccessCredentials", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .WithMany("DataSectionTemplates")
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

            modelBuilder.Entity("Server.Enteties.EstimationView.NetSheetSectionTemplate", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithOne("NetSheetSectionTemplate")
                        .HasForeignKey("Server.Enteties.EstimationView.NetSheetSectionTemplate", "EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.NetSheetSectionTemplate", "NetSheetSectionTemplate")
                        .WithMany("Columns")
                        .HasForeignKey("NetSheetSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NetSheetSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.License", b =>
                {
                    b.HasOne("Server.Enteties.Organization", "Organization")
                        .WithOne("License")
                        .HasForeignKey("Server.Enteties.License", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Server.Enteties.Role", b =>
                {
                    b.HasOne("Server.Enteties.Organization", "Organization")
                        .WithMany("Roles")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Server.Enteties.RoleRight", b =>
                {
                    b.HasOne("Server.Enteties.Role", "Role")
                        .WithMany("RoleRights")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Server.Enteties.RoleViewTemplate", b =>
                {
                    b.HasOne("Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany()
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Enteties.Role", "Role")
                        .WithMany("RoleViewTemplates")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Server.Enteties.User", b =>
                {
                    b.HasOne("Server.Enteties.License", "License")
                        .WithMany("Users")
                        .HasForeignKey("LicenseId");

                    b.HasOne("Server.Enteties.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Enteties.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("License");

                    b.Navigation("Organization");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Server.Enteties.UserRight", b =>
                {
                    b.HasOne("Server.Enteties.User", "User")
                        .WithMany("UserRights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                    b.Navigation("DataSectionTemplates");

                    b.Navigation("HeaderOrFooters");

                    b.Navigation("NetSheetSectionTemplate");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.NetSheetSectionTemplate", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.Navigation("CellFormat")
                        .IsRequired();
                });

            modelBuilder.Entity("Server.Enteties.License", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Server.Enteties.Organization", b =>
                {
                    b.Navigation("BidconCredentials");

                    b.Navigation("EstimationViewTemplates");

                    b.Navigation("License");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Server.Enteties.Role", b =>
                {
                    b.Navigation("RoleRights");

                    b.Navigation("RoleViewTemplates");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Server.Enteties.User", b =>
                {
                    b.Navigation("UserRights");

                    b.Navigation("UserViewTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
