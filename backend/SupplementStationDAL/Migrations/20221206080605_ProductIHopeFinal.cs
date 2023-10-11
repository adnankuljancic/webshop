using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementStationDAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductIHopeFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sold",
                table: "ProductSizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 6, 9, 6, 5, 707, DateTimeKind.Local).AddTicks(8327));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sold",
                table: "ProductSizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 6, 8, 54, 11, 367, DateTimeKind.Local).AddTicks(593));
        }
    }
}
