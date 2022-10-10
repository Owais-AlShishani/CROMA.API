using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CROMA.API.Migrations
{
    public partial class SeedingmoredataforOrdertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateFrom",
                value: new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "Comment", "DateFrom", "DateTo", "PhoneNumber", "UserName" },
                values: new object[] { 2, 2, "No Comment", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 962779654107L, "Omar" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "Comment", "DateFrom", "DateTo", "PhoneNumber", "UserName" },
                values: new object[] { 3, 3, "No Comment", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 96277050507L, "Ali" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateFrom",
                value: new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
