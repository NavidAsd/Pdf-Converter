using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class _SomeTblChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortLink",
                table: "SecurityLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortLink",
                table: "OtherFeaturesLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortLink",
                table: "OrganizersLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortLink",
                table: "OptimizersLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortLink",
                table: "ConverterLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "TreeHelpSteps",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortLink",
                table: "SecurityLogs");

            migrationBuilder.DropColumn(
                name: "ShortLink",
                table: "OtherFeaturesLogs");

            migrationBuilder.DropColumn(
                name: "ShortLink",
                table: "OrganizersLogs");

            migrationBuilder.DropColumn(
                name: "ShortLink",
                table: "OptimizersLogs");

            migrationBuilder.DropColumn(
                name: "ShortLink",
                table: "ConverterLogs");

            migrationBuilder.DropColumn(
               name: "VideoName",
               table: "TreeHelpSteps");
        }
    }
}
