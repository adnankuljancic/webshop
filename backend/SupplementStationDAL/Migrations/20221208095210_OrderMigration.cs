using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementStationDAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 10, 52, 10, 8, DateTimeKind.Local).AddTicks(2246));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 0, 17, 23, 115, DateTimeKind.Local).AddTicks(4955));
        }
    }
}
