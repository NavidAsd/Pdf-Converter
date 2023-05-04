using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class _HomwPageContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePageContexts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopTitleText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServicesH2Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainServicesPText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesInfoH1Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesInfoPText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageContexts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePageContexts");
        }
    }
}
