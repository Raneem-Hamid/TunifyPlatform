using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addSeedersDataForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", "00000000-0000-0000-0000-000000000000", "admin", "ADMIN" },
                    { "User", "00000000-0000-0000-0000-000000000000", "user", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 8, 27, 12, 30, 48, 190, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 8, 27, 12, 30, 48, 190, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_Date",
                value: new DateTime(2024, 8, 27, 12, 30, 48, 190, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 27, 12, 30, 48, 190, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 27, 12, 30, 48, 190, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 27, 12, 30, 48, 190, DateTimeKind.Local).AddTicks(7484));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User");

            migrationBuilder.UpdateData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 8, 22, 10, 54, 58, 254, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 8, 22, 10, 54, 58, 254, DateTimeKind.Local).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_Date",
                value: new DateTime(2024, 8, 22, 10, 54, 58, 254, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 22, 10, 54, 58, 254, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 22, 10, 54, 58, 254, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 22, 10, 54, 58, 254, DateTimeKind.Local).AddTicks(9514));
        }
    }
}
