using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplementStationDAL.Migrations
{
    /// <inheritdoc />
    public partial class addConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "productDescription",
                table: "Products",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productID", "image", "productDescription", "productName" },
                values: new object[] { -1, "https://cdn.shopify.com/s/files/1/1525/5556/products/whey-matrix-quad-blend-whey-protein-complex-545871_1024x1024.jpg?v=1657561376", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris gravida elit vel tellus facilisis, dapibus.", "Protein" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productID",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "productDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
