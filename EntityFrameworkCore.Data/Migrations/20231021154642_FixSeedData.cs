using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 10, 21, 15, 46, 42, 260, DateTimeKind.Unspecified).AddTicks(5510), "Tivoli Gardens F.C." });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 10, 21, 15, 46, 42, 260, DateTimeKind.Unspecified).AddTicks(5520), "Waterhouse F.C." });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 21, 15, 46, 42, 260, DateTimeKind.Unspecified).AddTicks(5520));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 10, 19, 19, 5, 30, 137, DateTimeKind.Unspecified).AddTicks(4710), "Tivoli Gardens FC" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 10, 19, 19, 5, 30, 137, DateTimeKind.Unspecified).AddTicks(4720), "Waterhouse F.C" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 19, 5, 30, 137, DateTimeKind.Unspecified).AddTicks(4720));
        }
    }
}
