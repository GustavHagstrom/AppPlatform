using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class SectionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Style",
                table: "CellFormat",
                newName: "BorderStyle");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SheetSectionTemplate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DataSectionTemplate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SheetSectionTemplate");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DataSectionTemplate");

            migrationBuilder.RenameColumn(
                name: "BorderStyle",
                table: "CellFormat",
                newName: "Style");
        }
    }
}
