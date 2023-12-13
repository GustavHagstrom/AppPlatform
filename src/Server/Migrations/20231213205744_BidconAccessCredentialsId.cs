using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class BidconAccessCredentialsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_BidconAccessCredentials_BidconCredentialsOrganizationId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_BidconCredentialsOrganizationId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "BidconCredentialsOrganizationId",
                table: "Organizations");

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

            migrationBuilder.AddColumn<string>(
                name: "BidconCredentialsOrganizationId",
                table: "Organizations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_BidconCredentialsOrganizationId",
                table: "Organizations",
                column: "BidconCredentialsOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_BidconAccessCredentials_BidconCredentialsOrganizationId",
                table: "Organizations",
                column: "BidconCredentialsOrganizationId",
                principalTable: "BidconAccessCredentials",
                principalColumn: "OrganizationId");
        }
    }
}
