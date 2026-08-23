using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockControlApi.Migrations
{
    /// <inheritdoc />
    public partial class Product_Removing_InternalCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_InternalCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InternalCode",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InternalCode",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_InternalCode",
                table: "Product",
                column: "InternalCode",
                unique: true);
        }
    }
}
