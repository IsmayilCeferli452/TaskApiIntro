using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiIntro.Migrations
{
    public partial class CreatedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(7991), "Category 1" },
                    { 2, new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(8000), "Category 2" },
                    { 3, new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(8001), "Category 3" },
                    { 4, new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(8002), "Category 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
