using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class estimation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estimations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    BidConId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CostBeforeChanges = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimations", x => x.Id);
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
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
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
                name: "EstimationQuickTags",
                columns: table => new
                {
                    EstimationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuickTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationQuickTags", x => new { x.EstimationId, x.QuickTagsId });
                    table.ForeignKey(
                        name: "FK_EstimationQuickTags_Estimations_EstimationId",
                        column: x => x.EstimationId,
                        principalTable: "Estimations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimationQuickTags_QuickTag_QuickTagsId",
                        column: x => x.QuickTagsId,
                        principalTable: "QuickTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimationSelectionTags",
                columns: table => new
                {
                    EstimationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectionTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationSelectionTags", x => new { x.EstimationId, x.SelectionTagsId });
                    table.ForeignKey(
                        name: "FK_EstimationSelectionTags_Estimations_EstimationId",
                        column: x => x.EstimationId,
                        principalTable: "Estimations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimationSelectionTags_SelectionTag_SelectionTagsId",
                        column: x => x.SelectionTagsId,
                        principalTable: "SelectionTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimationItemQuickTags",
                columns: table => new
                {
                    EstimationItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuickTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationItemQuickTags", x => new { x.EstimationItemId, x.QuickTagsId });
                    table.ForeignKey(
                        name: "FK_EstimationItemQuickTags_EstimationItem_EstimationItemId",
                        column: x => x.EstimationItemId,
                        principalTable: "EstimationItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimationItemQuickTags_QuickTag_QuickTagsId",
                        column: x => x.QuickTagsId,
                        principalTable: "QuickTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimationItemSelectionTags",
                columns: table => new
                {
                    EstimationItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectionTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationItemSelectionTags", x => new { x.EstimationItemId, x.SelectionTagsId });
                    table.ForeignKey(
                        name: "FK_EstimationItemSelectionTags_EstimationItem_EstimationItemId",
                        column: x => x.EstimationItemId,
                        principalTable: "EstimationItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimationItemSelectionTags_SelectionTag_SelectionTagsId",
                        column: x => x.SelectionTagsId,
                        principalTable: "SelectionTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_EstimationItemQuickTags_QuickTagsId",
                table: "EstimationItemQuickTags",
                column: "QuickTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationItemSelectionTags_SelectionTagsId",
                table: "EstimationItemSelectionTags",
                column: "SelectionTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationQuickTags_QuickTagsId",
                table: "EstimationQuickTags",
                column: "QuickTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationSelectionTags_SelectionTagsId",
                table: "EstimationSelectionTags",
                column: "SelectionTagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstimationItemQuickTags");

            migrationBuilder.DropTable(
                name: "EstimationItemSelectionTags");

            migrationBuilder.DropTable(
                name: "EstimationQuickTags");

            migrationBuilder.DropTable(
                name: "EstimationSelectionTags");

            migrationBuilder.DropTable(
                name: "EstimationItem");

            migrationBuilder.DropTable(
                name: "Estimations");
        }
    }
}
