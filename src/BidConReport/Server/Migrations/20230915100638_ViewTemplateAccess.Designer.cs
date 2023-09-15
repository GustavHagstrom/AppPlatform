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
    [Migration("20230915100638_ViewTemplateAccess")]
    partial class ViewTemplateAccess
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BidConReport.Server.Enteties.BidconCredentials", b =>
                {
                    b.Property<string>("OrganizationId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Database")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ServerAuthentication")
                        .HasColumnType("bit");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrganizationId");

                    b.ToTable("BidconCredentials");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.CellFormat", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.CellTemplate", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.DataColumn", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.DataSectionTemplate", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.HeaderOrFooter", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.NetSheetSectionTemplate", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.SheetColumn", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.License", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.Organization", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Role", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.RoleRight", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.RoleViewTemplate", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.User", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.UserRight", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.UserViewTemplate", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.BidconCredentials", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Organization", null)
                        .WithOne("BidconCredentials")
                        .HasForeignKey("BidConReport.Server.Enteties.BidconCredentials", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.CellFormat", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.CellTemplate", "CellTemplate")
                        .WithOne("Format")
                        .HasForeignKey("BidConReport.Server.Enteties.EstimationView.CellFormat", "CellTemplateId");

                    b.HasOne("BidConReport.Server.Enteties.EstimationView.SheetColumn", "SheetColumn")
                        .WithOne("CellFormat")
                        .HasForeignKey("BidConReport.Server.Enteties.EstimationView.CellFormat", "SheetColumnId");

                    b.Navigation("CellTemplate");

                    b.Navigation("SheetColumn");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.DataSectionTemplate", "DataSectionTemplate")
                        .WithMany("Cells")
                        .HasForeignKey("DataSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSectionTemplate");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.DataColumn", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.DataSectionTemplate", "DataSectionTemplate")
                        .WithMany("Columns")
                        .HasForeignKey("DataSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSectionTemplate");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationView")
                        .WithMany("DataSectionTemplates")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationView");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Organization", "Organization")
                        .WithMany("EstimationViewTemplates")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.HeaderOrFooter", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany("HeaderOrFooters")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.NetSheetSectionTemplate", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithOne("NetSheetSectionTemplate")
                        .HasForeignKey("BidConReport.Server.Enteties.EstimationView.NetSheetSectionTemplate", "EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.NetSheetSectionTemplate", "NetSheetSectionTemplate")
                        .WithMany("Columns")
                        .HasForeignKey("NetSheetSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NetSheetSectionTemplate");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.License", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Organization", "Organization")
                        .WithOne("License")
                        .HasForeignKey("BidConReport.Server.Enteties.License", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Role", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Organization", "Organization")
                        .WithMany("Roles")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.RoleRight", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Role", "Role")
                        .WithMany("RoleRights")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.RoleViewTemplate", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany()
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Role", "Role")
                        .WithMany("RoleViewTemplates")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.User", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.License", "License")
                        .WithMany("Users")
                        .HasForeignKey("LicenseId");

                    b.HasOne("BidConReport.Server.Enteties.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("License");

                    b.Navigation("Organization");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.UserRight", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.User", "User")
                        .WithMany("UserRights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.UserViewTemplate", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany()
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.User", "User")
                        .WithMany("UserViewTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.Navigation("Format")
                        .IsRequired();
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.Navigation("Cells");

                    b.Navigation("Columns");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.Navigation("DataSectionTemplates");

                    b.Navigation("HeaderOrFooters");

                    b.Navigation("NetSheetSectionTemplate");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.NetSheetSectionTemplate", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.Navigation("CellFormat")
                        .IsRequired();
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.License", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Organization", b =>
                {
                    b.Navigation("BidconCredentials");

                    b.Navigation("EstimationViewTemplates");

                    b.Navigation("License");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Role", b =>
                {
                    b.Navigation("RoleRights");

                    b.Navigation("RoleViewTemplates");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.User", b =>
                {
                    b.Navigation("UserRights");

                    b.Navigation("UserViewTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
