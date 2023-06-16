using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class Renamedcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizations_EstimationImportSettings_StandardEstimationSettingsId",
                table: "UserOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserOrganizations_CurrentUserOrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CurrentUserOrganizationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentUserOrganizationId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StandardEstimationSettingsId",
                table: "UserOrganizations",
                newName: "DefaultEstimationSettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizations_StandardEstimationSettingsId",
                table: "UserOrganizations",
                newName: "IX_UserOrganizations_DefaultEstimationSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizations_EstimationImportSettings_DefaultEstimationSettingsId",
                table: "UserOrganizations",
                column: "DefaultEstimationSettingsId",
                principalTable: "EstimationImportSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizations_EstimationImportSettings_DefaultEstimationSettingsId",
                table: "UserOrganizations");

            migrationBuilder.RenameColumn(
                name: "DefaultEstimationSettingsId",
                table: "UserOrganizations",
                newName: "StandardEstimationSettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizations_DefaultEstimationSettingsId",
                table: "UserOrganizations",
                newName: "IX_UserOrganizations_StandardEstimationSettingsId");

            migrationBuilder.AddColumn<int>(
                name: "CurrentUserOrganizationId",
                table: "Users",
                type: "int",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrentUserOrganizationId",
                table: "Users",
                column: "CurrentUserOrganizationId",
                unique: true,
                filter: "[CurrentUserOrganizationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizations_EstimationImportSettings_StandardEstimationSettingsId",
                table: "UserOrganizations",
                column: "StandardEstimationSettingsId",
                principalTable: "EstimationImportSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserOrganizations_CurrentUserOrganizationId",
                table: "Users",
                column: "CurrentUserOrganizationId",
                principalTable: "UserOrganizations",
                principalColumn: "Id");
        }
    }
}
