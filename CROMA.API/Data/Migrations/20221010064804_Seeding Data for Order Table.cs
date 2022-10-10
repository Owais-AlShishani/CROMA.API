using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CROMA.API.Migrations
{
    public partial class SeedingDataforOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "Comment", "DateFrom", "DateTo", "PhoneNumber", "UserName" },
                values: new object[] { 1, 1, "Nice Car", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 962776968787L, "Owais" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
