using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductService.Migrations
{
    /// <inheritdoc />
    public partial class AddNewSeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Tag" },
                values: new object[] { 3, "Apple M3", 2050f, "L003" });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Id", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, "1Red", 1 },
                    { 2, "1Blue", 1 },
                    { 3, "2Blue", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
