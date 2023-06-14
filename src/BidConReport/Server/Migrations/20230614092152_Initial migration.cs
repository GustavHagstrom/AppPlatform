using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
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
                    HiddenTag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HiddenUnitTag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UseRevisionAsSelectionTags = table.Column<bool>(type: "bit", nullable: false),
                    QuickTags = table.Column<string>(type: "NVARCHAR(1000)", maxLength: 1000, nullable: false),
                    SelectionTags = table.Column<string>(type: "NVARCHAR(1000)", maxLength: 1000, nullable: false)
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
                    QuickTags = table.Column<string>(type: "NVARCHAR(1000)", nullable: false),
                    SelectionTags = table.Column<string>(type: "NVARCHAR(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StandardEstimationSettingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_EstimationImportSettings_StandardEstimationSettingsId",
                        column: x => x.StandardEstimationSettingsId,
                        principalTable: "EstimationImportSettings",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_EstimationItem_EstimationId",
                table: "EstimationItem",
                column: "EstimationId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationItem_EstimationItemId",
                table: "EstimationItem",
                column: "EstimationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StandardEstimationSettingsId",
                table: "Users",
                column: "StandardEstimationSettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstimationItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Estimations");

            migrationBuilder.DropTable(
                name: "EstimationImportSettings");
        }
    }
}
