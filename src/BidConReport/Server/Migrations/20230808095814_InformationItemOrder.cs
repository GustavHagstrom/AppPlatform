using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class InformationItemOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "InformationItem");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "InformationItem",
                newName: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "InformationItem",
                newName: "Type");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "InformationItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
