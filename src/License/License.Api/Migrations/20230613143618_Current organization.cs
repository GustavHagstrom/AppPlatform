using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License.Api.Migrations
{
    /// <inheritdoc />
    public partial class Currentorganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentOrganizationName",
                table: "Users",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrentOrganizationName",
                table: "Users",
                column: "CurrentOrganizationName");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_CurrentOrganizationName",
                table: "Users",
                column: "CurrentOrganizationName",
                principalTable: "Organizations",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_CurrentOrganizationName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CurrentOrganizationName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentOrganizationName",
                table: "Users");
        }
    }
}
