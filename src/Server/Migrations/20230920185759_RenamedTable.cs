using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidconCredentials_Organizations_OrganizationId",
                table: "BidconCredentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidconCredentials",
                table: "BidconCredentials");

            migrationBuilder.RenameTable(
                name: "BidconCredentials",
                newName: "BidconAccessCredentials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidconAccessCredentials",
                table: "BidconAccessCredentials",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BidconAccessCredentials_Organizations_OrganizationId",
                table: "BidconAccessCredentials",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidconAccessCredentials_Organizations_OrganizationId",
                table: "BidconAccessCredentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidconAccessCredentials",
                table: "BidconAccessCredentials");

            migrationBuilder.RenameTable(
                name: "BidconAccessCredentials",
                newName: "BidconCredentials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidconCredentials",
                table: "BidconCredentials",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BidconCredentials_Organizations_OrganizationId",
                table: "BidconCredentials",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
