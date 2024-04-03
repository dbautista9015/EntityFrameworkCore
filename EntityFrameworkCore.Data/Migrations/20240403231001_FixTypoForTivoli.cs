using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoForTivoli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 3, 23, 10, 1, 352, DateTimeKind.Unspecified).AddTicks(610), "Tivoli Gardens F.C." });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 23, 10, 1, 352, DateTimeKind.Unspecified).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 23, 10, 1, 352, DateTimeKind.Unspecified).AddTicks(620));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 4, 3, 15, 8, 21, 240, DateTimeKind.Unspecified).AddTicks(4700), "Tivoli Gardens FC" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 15, 8, 21, 240, DateTimeKind.Unspecified).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 3, 15, 8, 21, 240, DateTimeKind.Unspecified).AddTicks(4700));
        }
    }
}
