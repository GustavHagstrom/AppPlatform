using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class SheetSectionList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheetColumn_NetSheetSectionTemplate_NetSheetSectionTemplateId",
                table: "SheetColumn");

            migrationBuilder.DropTable(
                name: "NetSheetSectionTemplate");

            migrationBuilder.CreateTable(
                name: "SheetSectionTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SheetType = table.Column<int>(type: "int", nullable: false),
                    EstimationViewTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetSectionTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetSectionTemplate_EstimationViewTemplates_EstimationViewTemplateId",
                        column: x => x.EstimationViewTemplateId,
                        principalTable: "EstimationViewTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SheetSectionTemplate_EstimationViewTemplateId",
                table: "SheetSectionTemplate",
                column: "EstimationViewTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SheetColumn_SheetSectionTemplate_NetSheetSectionTemplateId",
                table: "SheetColumn",
                column: "NetSheetSectionTemplateId",
                principalTable: "SheetSectionTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SheetColumn_SheetSectionTemplate_NetSheetSectionTemplateId",
                table: "SheetColumn");

            migrationBuilder.DropTable(
                name: "SheetSectionTemplate");

            migrationBuilder.CreateTable(
                name: "NetSheetSectionTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimationViewTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetSheetSectionTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetSheetSectionTemplate_EstimationViewTemplates_EstimationViewTemplateId",
                        column: x => x.EstimationViewTemplateId,
                        principalTable: "EstimationViewTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetSheetSectionTemplate_EstimationViewTemplateId",
                table: "NetSheetSectionTemplate",
                column: "EstimationViewTemplateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SheetColumn_NetSheetSectionTemplate_NetSheetSectionTemplateId",
                table: "SheetColumn",
                column: "NetSheetSectionTemplateId",
                principalTable: "NetSheetSectionTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
