using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class SettingsConversions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SelectionTags",
                table: "EstimationImportSettings",
                type: "NVARCHAR(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)");

            migrationBuilder.AlterColumn<string>(
                name: "QuickTags",
                table: "EstimationImportSettings",
                type: "NVARCHAR(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SelectionTags",
                table: "EstimationImportSettings",
                type: "NVARCHAR(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "QuickTags",
                table: "EstimationImportSettings",
                type: "NVARCHAR(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20)",
                oldMaxLength: 20);
        }
    }
}
