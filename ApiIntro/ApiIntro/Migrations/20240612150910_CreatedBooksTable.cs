using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiIntro.Migrations
{
    public partial class CreatedBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Author 1", new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5468), "Category 1" },
                    { 2, "Author 2", new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5469), "Category 2" },
                    { 3, "Author 3", new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5470), "Category 3" },
                    { 4, "Author 4", new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5471), "Category 4" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 19, 9, 10, 565, DateTimeKind.Local).AddTicks(5390));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 18, 42, 41, 289, DateTimeKind.Local).AddTicks(8002));
        }
    }
}
