using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class EstimationViewTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstimationViewTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationViewTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSectionTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RowCount = table.Column<int>(type: "int", nullable: false),
                    EstimationViewTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSectionTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSectionTemplate_EstimationViewTemplates_EstimationViewTemplateId",
                        column: x => x.EstimationViewTemplateId,
                        principalTable: "EstimationViewTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeaderOrFooter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    EstimationViewTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderOrFooter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeaderOrFooter_EstimationViewTemplates_EstimationViewTemplateId",
                        column: x => x.EstimationViewTemplateId,
                        principalTable: "EstimationViewTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NetSheetSectionTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    EstimationViewTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CellTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSectionTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellTemplate_DataSectionTemplate_DataSectionTemplateId",
                        column: x => x.DataSectionTemplateId,
                        principalTable: "DataSectionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataColumn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    WidthPercent = table.Column<int>(type: "int", nullable: false),
                    DataSectionTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataColumn_DataSectionTemplate_DataSectionTemplateId",
                        column: x => x.DataSectionTemplateId,
                        principalTable: "DataSectionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SheetColumn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    WidthPercent = table.Column<int>(type: "int", nullable: false),
                    ColumnType = table.Column<int>(type: "int", nullable: false),
                    NetSheetSectionTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheetColumn_NetSheetSectionTemplate_NetSheetSectionTemplateId",
                        column: x => x.NetSheetSectionTemplateId,
                        principalTable: "NetSheetSectionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CellFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FontFamily = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    Bold = table.Column<bool>(type: "bit", nullable: false),
                    Italic = table.Column<bool>(type: "bit", nullable: false),
                    Underline = table.Column<bool>(type: "bit", nullable: false),
                    Align = table.Column<int>(type: "int", nullable: false),
                    Justify = table.Column<int>(type: "int", nullable: false),
                    FormatType = table.Column<int>(type: "int", nullable: false),
                    ThoasandsSeparator = table.Column<bool>(type: "bit", nullable: false),
                    DecimalCount = table.Column<int>(type: "int", nullable: false),
                    IncludeTimeOfDay = table.Column<bool>(type: "bit", nullable: false),
                    BorderLeft = table.Column<bool>(type: "bit", nullable: false),
                    BorderTop = table.Column<bool>(type: "bit", nullable: false),
                    BorderRight = table.Column<bool>(type: "bit", nullable: false),
                    BorderBottom = table.Column<bool>(type: "bit", nullable: false),
                    Style = table.Column<int>(type: "int", nullable: false),
                    SheetColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CellTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellFormat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CellFormat_CellTemplate_CellTemplateId",
                        column: x => x.CellTemplateId,
                        principalTable: "CellTemplate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CellFormat_SheetColumn_SheetColumnId",
                        column: x => x.SheetColumnId,
                        principalTable: "SheetColumn",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CellFormat_CellTemplateId",
                table: "CellFormat",
                column: "CellTemplateId",
                unique: true,
                filter: "[CellTemplateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CellFormat_SheetColumnId",
                table: "CellFormat",
                column: "SheetColumnId",
                unique: true,
                filter: "[SheetColumnId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CellTemplate_DataSectionTemplateId",
                table: "CellTemplate",
                column: "DataSectionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DataColumn_DataSectionTemplateId",
                table: "DataColumn",
                column: "DataSectionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSectionTemplate_EstimationViewTemplateId",
                table: "DataSectionTemplate",
                column: "EstimationViewTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderOrFooter_EstimationViewTemplateId",
                table: "HeaderOrFooter",
                column: "EstimationViewTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_NetSheetSectionTemplate_EstimationViewTemplateId",
                table: "NetSheetSectionTemplate",
                column: "EstimationViewTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheetColumn_NetSheetSectionTemplateId",
                table: "SheetColumn",
                column: "NetSheetSectionTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CellFormat");

            migrationBuilder.DropTable(
                name: "DataColumn");

            migrationBuilder.DropTable(
                name: "HeaderOrFooter");

            migrationBuilder.DropTable(
                name: "CellTemplate");

            migrationBuilder.DropTable(
                name: "SheetColumn");

            migrationBuilder.DropTable(
                name: "DataSectionTemplate");

            migrationBuilder.DropTable(
                name: "NetSheetSectionTemplate");

            migrationBuilder.DropTable(
                name: "EstimationViewTemplates");
        }
    }
}
