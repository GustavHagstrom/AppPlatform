﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstimationImportSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CostFactorAccount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CostBeforeChangesAccount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NetCostAccount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HiddenTag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HiddenUnitTag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UseRevisionAsSelectionTags = table.Column<bool>(type: "bit", nullable: false),
                    QuickTags = table.Column<string>(type: "NVARCHAR(1000)", maxLength: 1000, nullable: true),
                    SelectionTags = table.Column<string>(type: "NVARCHAR(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationImportSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estimations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BidConId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Representative = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supervisor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CostBeforeChanges = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HiddenUnitAndAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuickTags = table.Column<string>(type: "NVARCHAR(1000)", nullable: false),
                    SelectionTags = table.Column<string>(type: "NVARCHAR(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FontProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FontName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    Bold = table.Column<bool>(type: "bit", nullable: false),
                    Italic = table.Column<bool>(type: "bit", nullable: false),
                    Underline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FontProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutOrder = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDarkMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstimationItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    ChangedToRowNumber = table.Column<int>(type: "int", nullable: true),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DisplayedUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    DisplayedQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitCost = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Tags = table.Column<string>(type: "NVARCHAR(1000)", nullable: false),
                    EstimationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstimationItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimationItem_EstimationItem_EstimationItemId",
                        column: x => x.EstimationItemId,
                        principalTable: "EstimationItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstimationItem_Estimations_EstimationId",
                        column: x => x.EstimationId,
                        principalTable: "Estimations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HeaderDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FontId = table.Column<int>(type: "int", nullable: false),
                    ValueCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeaderDefinition_FontProperties_FontId",
                        column: x => x.FontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InformationSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LayoutOrder = table.Column<int>(type: "int", nullable: false),
                    TitleFontId = table.Column<int>(type: "int", nullable: false),
                    ValueFontId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformationSection_FontProperties_TitleFontId",
                        column: x => x.TitleFontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformationSection_FontProperties_ValueFontId",
                        column: x => x.ValueFontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutOrder = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ShowChanges = table.Column<bool>(type: "bit", nullable: false),
                    PriceWithoutChangesDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChangesDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PriceWithChangesDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PriceFontId = table.Column<int>(type: "int", nullable: false),
                    CommentFontId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceSection_FontProperties_CommentFontId",
                        column: x => x.CommentFontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PriceSection_FontProperties_PriceFontId",
                        column: x => x.PriceFontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TitleSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutOrder = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FontId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleSection_FontProperties_FontId",
                        column: x => x.FontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ColumnDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableSectionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DataSource = table.Column<int>(type: "int", nullable: false),
                    GroupFontId = table.Column<int>(type: "int", nullable: false),
                    PartFontId = table.Column<int>(type: "int", nullable: false),
                    CelleFontId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColumnDefinition_FontProperties_CelleFontId",
                        column: x => x.CelleFontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnDefinition_FontProperties_GroupFontId",
                        column: x => x.GroupFontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnDefinition_FontProperties_PartFontId",
                        column: x => x.PartFontId,
                        principalTable: "FontProperties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnDefinition_TableSection_TableSectionId",
                        column: x => x.TableSectionId,
                        principalTable: "TableSection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultEstimationSettingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_EstimationImportSettings_DefaultEstimationSettingsId",
                        column: x => x.DefaultEstimationSettingsId,
                        principalTable: "EstimationImportSettings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserOrganizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InformationSectionId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformationItem_InformationSection_InformationSectionId",
                        column: x => x.InformationSectionId,
                        principalTable: "InformationSection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TopLeftHeaderId = table.Column<int>(type: "int", nullable: false),
                    TopRightHeaderId = table.Column<int>(type: "int", nullable: false),
                    TitleSectionId = table.Column<int>(type: "int", nullable: false),
                    InformationSectionId = table.Column<int>(type: "int", nullable: false),
                    PriceSectionId = table.Column<int>(type: "int", nullable: false),
                    TableSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportTemplate_HeaderDefinition_TopLeftHeaderId",
                        column: x => x.TopLeftHeaderId,
                        principalTable: "HeaderDefinition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportTemplate_HeaderDefinition_TopRightHeaderId",
                        column: x => x.TopRightHeaderId,
                        principalTable: "HeaderDefinition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportTemplate_InformationSection_InformationSectionId",
                        column: x => x.InformationSectionId,
                        principalTable: "InformationSection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportTemplate_PriceSection_PriceSectionId",
                        column: x => x.PriceSectionId,
                        principalTable: "PriceSection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportTemplate_TableSection_TableSectionId",
                        column: x => x.TableSectionId,
                        principalTable: "TableSection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportTemplate_TitleSection_TitleSectionId",
                        column: x => x.TitleSectionId,
                        principalTable: "TitleSection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnDefinition_CelleFontId",
                table: "ColumnDefinition",
                column: "CelleFontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColumnDefinition_GroupFontId",
                table: "ColumnDefinition",
                column: "GroupFontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColumnDefinition_PartFontId",
                table: "ColumnDefinition",
                column: "PartFontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColumnDefinition_TableSectionId",
                table: "ColumnDefinition",
                column: "TableSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationItem_EstimationId",
                table: "EstimationItem",
                column: "EstimationId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationItem_EstimationItemId",
                table: "EstimationItem",
                column: "EstimationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderDefinition_FontId",
                table: "HeaderDefinition",
                column: "FontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformationItem_InformationSectionId",
                table: "InformationItem",
                column: "InformationSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationSection_TitleFontId",
                table: "InformationSection",
                column: "TitleFontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformationSection_ValueFontId",
                table: "InformationSection",
                column: "ValueFontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceSection_CommentFontId",
                table: "PriceSection",
                column: "CommentFontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceSection_PriceFontId",
                table: "PriceSection",
                column: "PriceFontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplate_InformationSectionId",
                table: "ReportTemplate",
                column: "InformationSectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplate_PriceSectionId",
                table: "ReportTemplate",
                column: "PriceSectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplate_TableSectionId",
                table: "ReportTemplate",
                column: "TableSectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplate_TitleSectionId",
                table: "ReportTemplate",
                column: "TitleSectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplate_TopLeftHeaderId",
                table: "ReportTemplate",
                column: "TopLeftHeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplate_TopRightHeaderId",
                table: "ReportTemplate",
                column: "TopRightHeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TitleSection_FontId",
                table: "TitleSection",
                column: "FontId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_DefaultEstimationSettingsId",
                table: "UserOrganizations",
                column: "DefaultEstimationSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_UserId",
                table: "UserOrganizations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnDefinition");

            migrationBuilder.DropTable(
                name: "EstimationItem");

            migrationBuilder.DropTable(
                name: "InformationItem");

            migrationBuilder.DropTable(
                name: "ReportTemplate");

            migrationBuilder.DropTable(
                name: "UserOrganizations");

            migrationBuilder.DropTable(
                name: "Estimations");

            migrationBuilder.DropTable(
                name: "HeaderDefinition");

            migrationBuilder.DropTable(
                name: "InformationSection");

            migrationBuilder.DropTable(
                name: "PriceSection");

            migrationBuilder.DropTable(
                name: "TableSection");

            migrationBuilder.DropTable(
                name: "TitleSection");

            migrationBuilder.DropTable(
                name: "EstimationImportSettings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FontProperties");
        }
    }
}
