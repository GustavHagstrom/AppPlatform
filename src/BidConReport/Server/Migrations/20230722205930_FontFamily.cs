using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class FontFamily : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FontProperties_FontFamilies_FontFamilyId",
                table: "FontProperties");

            migrationBuilder.DropTable(
                name: "FontFamilies");

            migrationBuilder.DropIndex(
                name: "IX_FontProperties_FontFamilyId",
                table: "FontProperties");

            migrationBuilder.DropColumn(
                name: "FontFamilyId",
                table: "FontProperties");

            migrationBuilder.AddColumn<string>(
                name: "FontFamily",
                table: "FontProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FontFamily",
                table: "FontProperties");

            migrationBuilder.AddColumn<int>(
                name: "FontFamilyId",
                table: "FontProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FontFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FontFamilies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FontProperties_FontFamilyId",
                table: "FontProperties",
                column: "FontFamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FontProperties_FontFamilies_FontFamilyId",
                table: "FontProperties",
                column: "FontFamilyId",
                principalTable: "FontFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
