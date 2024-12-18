﻿// <auto-generated />
using System;
using AppPlatform.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppPlatform.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240216125215_AuthorizatinEnteties")]
    partial class AuthorizatinEnteties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("AppPlatform.Core.Enteties.Authorization.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.Authorization.RoleAccess", b =>
                {
                    b.Property<string>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("AccessId")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId", "AccessId");

                    b.ToTable("RoleAccess");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.Authorization.UserAccess", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("AccessId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "AccessId");

                    b.ToTable("UserAccess");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.Authorization.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.BidconAccessCredentials", b =>
                {
                    b.Property<string>("TenantId")
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

                    b.HasKey("TenantId");

                    b.ToTable("BidconAccessCredentials");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.CellFormat", b =>
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

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.CellTemplate", b =>
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

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.DataColumn", b =>
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

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.DataSectionTemplate", b =>
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

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EstimationViewTemplates");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.HeaderOrFooter", b =>
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

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.SheetColumn", b =>
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

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.SheetSectionTemplate", b =>
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

            modelBuilder.Entity("AppPlatform.Core.Enteties.UserSettings", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.Authorization.RoleAccess", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.Authorization.Role", "Role")
                        .WithMany("RoleAccesses")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.Authorization.UserRole", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.Authorization.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.CellFormat", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.CellTemplate", "CellTemplate")
                        .WithOne("Format")
                        .HasForeignKey("AppPlatform.Core.Enteties.EstimationView.CellFormat", "CellTemplateId");

                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.SheetColumn", "SheetColumn")
                        .WithOne("CellFormat")
                        .HasForeignKey("AppPlatform.Core.Enteties.EstimationView.CellFormat", "SheetColumnId");

                    b.Navigation("CellTemplate");

                    b.Navigation("SheetColumn");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.DataSectionTemplate", "DataSectionTemplate")
                        .WithMany("Cells")
                        .HasForeignKey("DataSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSectionTemplate");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.DataColumn", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.DataSectionTemplate", "DataSectionTemplate")
                        .WithMany("Columns")
                        .HasForeignKey("DataSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSectionTemplate");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.EstimationViewTemplate", "EstimationView")
                        .WithMany("DataSections")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationView");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.HeaderOrFooter", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany("HeaderOrFooters")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.SheetSectionTemplate", "NetSheetSectionTemplate")
                        .WithMany("Columns")
                        .HasForeignKey("NetSheetSectionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NetSheetSectionTemplate");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.SheetSectionTemplate", b =>
                {
                    b.HasOne("AppPlatform.Core.Enteties.EstimationView.EstimationViewTemplate", "EstimationViewTemplate")
                        .WithMany("SheetSections")
                        .HasForeignKey("EstimationViewTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimationViewTemplate");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.Authorization.Role", b =>
                {
                    b.Navigation("RoleAccesses");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.CellTemplate", b =>
                {
                    b.Navigation("Format")
                        .IsRequired();
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.DataSectionTemplate", b =>
                {
                    b.Navigation("Cells");

                    b.Navigation("Columns");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.EstimationViewTemplate", b =>
                {
                    b.Navigation("DataSections");

                    b.Navigation("HeaderOrFooters");

                    b.Navigation("SheetSections");
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.SheetColumn", b =>
                {
                    b.Navigation("CellFormat")
                        .IsRequired();
                });

            modelBuilder.Entity("AppPlatform.Core.Enteties.EstimationView.SheetSectionTemplate", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
