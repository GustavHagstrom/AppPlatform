using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidConReport.Server.Migrations
{
    /// <inheritdoc />
    public partial class NullableFonts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplate_HeaderDefinition_TopLeftHeaderId",
                table: "ReportTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplate_HeaderDefinition_TopRightHeaderId",
                table: "ReportTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplate_InformationSection_InformationSectionId",
                table: "ReportTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplate_PriceSection_PriceSectionId",
                table: "ReportTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplate_TableSection_TableSectionId",
                table: "ReportTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplate_TitleSection_TitleSectionId",
                table: "ReportTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTemplate",
                table: "ReportTemplate");

            migrationBuilder.RenameTable(
                name: "ReportTemplate",
                newName: "ReportTemplates");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_TopRightHeaderId",
                table: "ReportTemplates",
                newName: "IX_ReportTemplates_TopRightHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_TopLeftHeaderId",
                table: "ReportTemplates",
                newName: "IX_ReportTemplates_TopLeftHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_TitleSectionId",
                table: "ReportTemplates",
                newName: "IX_ReportTemplates_TitleSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_TableSectionId",
                table: "ReportTemplates",
                newName: "IX_ReportTemplates_TableSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_PriceSectionId",
                table: "ReportTemplates",
                newName: "IX_ReportTemplates_PriceSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplate_InformationSectionId",
                table: "ReportTemplates",
                newName: "IX_ReportTemplates_InformationSectionId");

            migrationBuilder.AddColumn<int>(
                name: "DefaultReportTemplateId",
                table: "UserOrganizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTemplates",
                table: "ReportTemplates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_DefaultReportTemplateId",
                table: "UserOrganizations",
                column: "DefaultReportTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplates_HeaderDefinition_TopLeftHeaderId",
                table: "ReportTemplates",
                column: "TopLeftHeaderId",
                principalTable: "HeaderDefinition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplates_HeaderDefinition_TopRightHeaderId",
                table: "ReportTemplates",
                column: "TopRightHeaderId",
                principalTable: "HeaderDefinition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplates_InformationSection_InformationSectionId",
                table: "ReportTemplates",
                column: "InformationSectionId",
                principalTable: "InformationSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplates_PriceSection_PriceSectionId",
                table: "ReportTemplates",
                column: "PriceSectionId",
                principalTable: "PriceSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplates_TableSection_TableSectionId",
                table: "ReportTemplates",
                column: "TableSectionId",
                principalTable: "TableSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplates_TitleSection_TitleSectionId",
                table: "ReportTemplates",
                column: "TitleSectionId",
                principalTable: "TitleSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizations_ReportTemplates_DefaultReportTemplateId",
                table: "UserOrganizations",
                column: "DefaultReportTemplateId",
                principalTable: "ReportTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplates_HeaderDefinition_TopLeftHeaderId",
                table: "ReportTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplates_HeaderDefinition_TopRightHeaderId",
                table: "ReportTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplates_InformationSection_InformationSectionId",
                table: "ReportTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplates_PriceSection_PriceSectionId",
                table: "ReportTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplates_TableSection_TableSectionId",
                table: "ReportTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportTemplates_TitleSection_TitleSectionId",
                table: "ReportTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizations_ReportTemplates_DefaultReportTemplateId",
                table: "UserOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_UserOrganizations_DefaultReportTemplateId",
                table: "UserOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTemplates",
                table: "ReportTemplates");

            migrationBuilder.DropColumn(
                name: "DefaultReportTemplateId",
                table: "UserOrganizations");

            migrationBuilder.RenameTable(
                name: "ReportTemplates",
                newName: "ReportTemplate");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplates_TopRightHeaderId",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_TopRightHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplates_TopLeftHeaderId",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_TopLeftHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplates_TitleSectionId",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_TitleSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplates_TableSectionId",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_TableSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplates_PriceSectionId",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_PriceSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTemplates_InformationSectionId",
                table: "ReportTemplate",
                newName: "IX_ReportTemplate_InformationSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTemplate",
                table: "ReportTemplate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplate_HeaderDefinition_TopLeftHeaderId",
                table: "ReportTemplate",
                column: "TopLeftHeaderId",
                principalTable: "HeaderDefinition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplate_HeaderDefinition_TopRightHeaderId",
                table: "ReportTemplate",
                column: "TopRightHeaderId",
                principalTable: "HeaderDefinition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplate_InformationSection_InformationSectionId",
                table: "ReportTemplate",
                column: "InformationSectionId",
                principalTable: "InformationSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplate_PriceSection_PriceSectionId",
                table: "ReportTemplate",
                column: "PriceSectionId",
                principalTable: "PriceSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplate_TableSection_TableSectionId",
                table: "ReportTemplate",
                column: "TableSectionId",
                principalTable: "TableSection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportTemplate_TitleSection_TitleSectionId",
                table: "ReportTemplate",
                column: "TitleSectionId",
                principalTable: "TitleSection",
                principalColumn: "Id");
        }
    }
}
