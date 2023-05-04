using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class _OtherFeaturesLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherFeaturesLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertTime = table.Column<DateTime>(type: "date", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "date", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "date", nullable: true),
                    UserIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FileInputName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileInputSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileOutName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRImage = table.Column<string>(type: "nvarchar(max)", nullable: true)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherFeaturesLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherFeaturesLogs");
        }
    }
}
