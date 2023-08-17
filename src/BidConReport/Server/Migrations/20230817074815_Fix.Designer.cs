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
    [Migration("20230817074815_Fix")]
    partial class Fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BidConReport.Server.Enteties.Estimation", b =>
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

                    b.Property<string>("HiddenUnitAndAmount")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectionTags")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1000)");

                    b.Property<string>("Supervisor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Estimations");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationImportSettings", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationItem", b =>
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

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.ColumnDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColumnHeader")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DataSource")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("TableSectionId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableSectionId");

                    b.ToTable("ColumnDefinition");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.FontProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Bold")
                        .HasColumnType("bit");

                    b.Property<string>("FontFamily")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FontSize")
                        .HasColumnType("int");

                    b.Property<bool>("Italic")
                        .HasColumnType("bit");

                    b.Property<bool>("Underline")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("FontProperties");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.HeaderDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FontId")
                        .HasColumnType("int");

                    b.Property<string>("ValueCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FontId");

                    b.ToTable("HeaderDefinition");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.InformationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InformationSectionId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InformationSectionId");

                    b.ToTable("InformationItem");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.InformationSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("LayoutOrder")
                        .HasColumnType("int");

                    b.Property<int>("TitleFontId")
                        .HasColumnType("int");

                    b.Property<int>("ValueFontId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TitleFontId");

                    b.HasIndex("ValueFontId");

                    b.ToTable("InformationSection");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.PriceSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChangesDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Comment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CommentFontId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("LayoutOrder")
                        .HasColumnType("int");

                    b.Property<int>("PriceFontId")
                        .HasColumnType("int");

                    b.Property<string>("PriceWithChangesDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PriceWithoutChangesDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ShowChanges")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CommentFontId");

                    b.HasIndex("PriceFontId");

                    b.ToTable("PriceSection");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.ReportTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InformationSectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PriceSectionId")
                        .HasColumnType("int");

                    b.Property<int>("TableSectionId")
                        .HasColumnType("int");

                    b.Property<int>("TitleSectionId")
                        .HasColumnType("int");

                    b.Property<int>("TopLeftHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("TopRightHeaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InformationSectionId");

                    b.HasIndex("PriceSectionId");

                    b.HasIndex("TableSectionId");

                    b.HasIndex("TitleSectionId");

                    b.HasIndex("TopLeftHeaderId");

                    b.HasIndex("TopRightHeaderId");

                    b.ToTable("ReportTemplates");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.TableSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CellFontId")
                        .HasColumnType("int");

                    b.Property<int>("ColumnHeaderFontId")
                        .HasColumnType("int");

                    b.Property<int>("GroupFontId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("LayoutOrder")
                        .HasColumnType("int");

                    b.Property<int>("PartFontId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CellFontId");

                    b.HasIndex("ColumnHeaderFontId");

                    b.HasIndex("GroupFontId");

                    b.HasIndex("PartFontId");

                    b.ToTable("TableSection");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.TitleSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FontId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("LayoutOrder")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FontId");

                    b.ToTable("TitleSection");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.UserOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DefaultEstimationSettingsId")
                        .HasColumnType("int");

                    b.Property<int?>("DefaultReportTemplateId")
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

                    b.HasIndex("DefaultReportTemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrganizations");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationItem", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Estimation", null)
                        .WithMany("Items")
                        .HasForeignKey("EstimationId");

                    b.HasOne("BidConReport.Server.Enteties.EstimationItem", null)
                        .WithMany("Items")
                        .HasForeignKey("EstimationItemId");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.ColumnDefinition", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.TableSection", null)
                        .WithMany("Columns")
                        .HasForeignKey("TableSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.HeaderDefinition", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "Font")
                        .WithMany()
                        .HasForeignKey("FontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Font");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.InformationItem", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.InformationSection", null)
                        .WithMany("Items")
                        .HasForeignKey("InformationSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.InformationSection", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "TitleFont")
                        .WithMany()
                        .HasForeignKey("TitleFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "ValueFont")
                        .WithMany()
                        .HasForeignKey("ValueFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TitleFont");

                    b.Navigation("ValueFont");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.PriceSection", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "CommentFont")
                        .WithMany()
                        .HasForeignKey("CommentFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "PriceFont")
                        .WithMany()
                        .HasForeignKey("PriceFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CommentFont");

                    b.Navigation("PriceFont");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.ReportTemplate", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.InformationSection", "InformationSection")
                        .WithMany()
                        .HasForeignKey("InformationSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.PriceSection", "PriceSection")
                        .WithMany()
                        .HasForeignKey("PriceSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.TableSection", "TableSection")
                        .WithMany()
                        .HasForeignKey("TableSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.TitleSection", "TitleSection")
                        .WithMany()
                        .HasForeignKey("TitleSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.HeaderDefinition", "TopLeftHeader")
                        .WithMany()
                        .HasForeignKey("TopLeftHeaderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.HeaderDefinition", "TopRightHeader")
                        .WithMany()
                        .HasForeignKey("TopRightHeaderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("InformationSection");

                    b.Navigation("PriceSection");

                    b.Navigation("TableSection");

                    b.Navigation("TitleSection");

                    b.Navigation("TopLeftHeader");

                    b.Navigation("TopRightHeader");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.TableSection", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "CellFont")
                        .WithMany()
                        .HasForeignKey("CellFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "ColumnHeaderFont")
                        .WithMany()
                        .HasForeignKey("ColumnHeaderFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "GroupFont")
                        .WithMany()
                        .HasForeignKey("GroupFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "PartFont")
                        .WithMany()
                        .HasForeignKey("PartFontId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CellFont");

                    b.Navigation("ColumnHeaderFont");

                    b.Navigation("GroupFont");

                    b.Navigation("PartFont");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.TitleSection", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.Report.FontProperties", "Font")
                        .WithMany()
                        .HasForeignKey("FontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Font");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.UserOrganization", b =>
                {
                    b.HasOne("BidConReport.Server.Enteties.EstimationImportSettings", "DefaultEstimationSettings")
                        .WithMany()
                        .HasForeignKey("DefaultEstimationSettingsId");

                    b.HasOne("BidConReport.Server.Enteties.Report.ReportTemplate", "DefaultReportTemplate")
                        .WithMany()
                        .HasForeignKey("DefaultReportTemplateId");

                    b.HasOne("BidConReport.Server.Enteties.User", "User")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DefaultEstimationSettings");

                    b.Navigation("DefaultReportTemplate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Estimation", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.EstimationItem", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.InformationSection", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.Report.TableSection", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("BidConReport.Server.Enteties.User", b =>
                {
                    b.Navigation("UserOrganizations");
                });
#pragma warning restore 612, 618
        }
    }
}
