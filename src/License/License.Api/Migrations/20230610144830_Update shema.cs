using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace License.Api.Migrations
{
    /// <inheritdoc />
    public partial class Updateshema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Applications_ApplicationId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Organizations_OrganizationId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Applications_ApplicationId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ApplicationId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_ApplicationId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_OrganizationId",
                table: "Licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                table: "Licenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Licenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Licenses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Applications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationName",
                table: "Users",
                column: "OrganizationName");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ApplicationName",
                table: "Roles",
                column: "ApplicationName");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ApplicationName",
                table: "Licenses",
                column: "ApplicationName");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_OrganizationName",
                table: "Licenses",
                column: "OrganizationName");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Applications_ApplicationName",
                table: "Licenses",
                column: "ApplicationName",
                principalTable: "Applications",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Organizations_OrganizationName",
                table: "Licenses",
                column: "OrganizationName",
                principalTable: "Organizations",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Applications_ApplicationName",
                table: "Roles",
                column: "ApplicationName",
                principalTable: "Applications",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationName",
                table: "Users",
                column: "OrganizationName",
                principalTable: "Organizations",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Applications_ApplicationName",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Organizations_OrganizationName",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Applications_ApplicationName",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ApplicationName",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_ApplicationName",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_OrganizationName",
                table: "Licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApplicationName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ApplicationName",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Licenses");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ApplicationId",
                table: "Roles",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ApplicationId",
                table: "Licenses",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_OrganizationId",
                table: "Licenses",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Applications_ApplicationId",
                table: "Licenses",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Organizations_OrganizationId",
                table: "Licenses",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Applications_ApplicationId",
                table: "Roles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
