using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License.Api.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Organizations_OrganizationName",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizations_Organizations_OrganizationsName",
                table: "UserOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_CurrentOrganizationName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CurrentOrganizationName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrganizations",
                table: "UserOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_OrganizationName",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "CurrentOrganizationName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizationsName",
                table: "UserOrganizations");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Licenses");

            migrationBuilder.AddColumn<int>(
                name: "CurrentOrganizationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationsId",
                table: "UserOrganizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrganizations",
                table: "UserOrganizations",
                columns: new[] { "OrganizationsId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrentOrganizationId",
                table: "Users",
                column: "CurrentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_OrganizationId",
                table: "Licenses",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Organizations_OrganizationId",
                table: "Licenses",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizations_Organizations_OrganizationsId",
                table: "UserOrganizations",
                column: "OrganizationsId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_CurrentOrganizationId",
                table: "Users",
                column: "CurrentOrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Organizations_OrganizationId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizations_Organizations_OrganizationsId",
                table: "UserOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_CurrentOrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CurrentOrganizationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrganizations",
                table: "UserOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_OrganizationId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "CurrentOrganizationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizationsId",
                table: "UserOrganizations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Licenses");

            migrationBuilder.AddColumn<string>(
                name: "CurrentOrganizationName",
                table: "Users",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationsName",
                table: "UserOrganizations",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Licenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrganizations",
                table: "UserOrganizations",
                columns: new[] { "OrganizationsName", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CurrentOrganizationName",
                table: "Users",
                column: "CurrentOrganizationName");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_OrganizationName",
                table: "Licenses",
                column: "OrganizationName");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Organizations_OrganizationName",
                table: "Licenses",
                column: "OrganizationName",
                principalTable: "Organizations",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizations_Organizations_OrganizationsName",
                table: "UserOrganizations",
                column: "OrganizationsName",
                principalTable: "Organizations",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_CurrentOrganizationName",
                table: "Users",
                column: "CurrentOrganizationName",
                principalTable: "Organizations",
                principalColumn: "Name");
        }
    }
}
