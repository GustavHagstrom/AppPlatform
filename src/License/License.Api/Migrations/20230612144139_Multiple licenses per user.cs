using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License.Api.Migrations
{
    /// <inheritdoc />
    public partial class Multiplelicensesperuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LicenseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserLicenses",
                columns: table => new
                {
                    LicensesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLicenses", x => new { x.LicensesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserLicenses_Licenses_LicensesId",
                        column: x => x.LicensesId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLicenses_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLicenses_UsersId",
                table: "UserLicenses",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLicenses");

            migrationBuilder.AddColumn<int>(
                name: "LicenseId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LicenseId",
                table: "Users",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
