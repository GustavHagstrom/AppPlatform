using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class TagsAndImportSettings : Migration
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
                    SettingsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CostFactorAccount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CostBeforeChangesAccount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NetCostAccount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HiddenTag = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationImportSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuickTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectionTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingQuickTags",
                columns: table => new
                {
                    EstimationImportSettingsId = table.Column<int>(type: "int", nullable: false),
                    QuickTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingQuickTags", x => new { x.EstimationImportSettingsId, x.QuickTagsId });
                    table.ForeignKey(
                        name: "FK_SettingQuickTags_EstimationImportSettings_EstimationImportSettingsId",
                        column: x => x.EstimationImportSettingsId,
                        principalTable: "EstimationImportSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingQuickTags_QuickTag_QuickTagsId",
                        column: x => x.QuickTagsId,
                        principalTable: "QuickTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingSelectionTags",
                columns: table => new
                {
                    EstimationImportSettingsId = table.Column<int>(type: "int", nullable: false),
                    SelectionTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingSelectionTags", x => new { x.EstimationImportSettingsId, x.SelectionTagsId });
                    table.ForeignKey(
                        name: "FK_SettingSelectionTags_EstimationImportSettings_EstimationImportSettingsId",
                        column: x => x.EstimationImportSettingsId,
                        principalTable: "EstimationImportSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingSelectionTags_SelectionTag_SelectionTagsId",
                        column: x => x.SelectionTagsId,
                        principalTable: "SelectionTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettingQuickTags_QuickTagsId",
                table: "SettingQuickTags",
                column: "QuickTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingSelectionTags_SelectionTagsId",
                table: "SettingSelectionTags",
                column: "SelectionTagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingQuickTags");

            migrationBuilder.DropTable(
                name: "SettingSelectionTags");

            migrationBuilder.DropTable(
                name: "QuickTag");

            migrationBuilder.DropTable(
                name: "EstimationImportSettings");

            migrationBuilder.DropTable(
                name: "SelectionTag");
        }
    }
}
