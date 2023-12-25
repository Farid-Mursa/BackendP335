using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P335_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddTableSaleProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SaleProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaleProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProducts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleProductId",
                table: "Products",
                column: "SaleProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SaleProducts_SaleProductId",
                table: "Products",
                column: "SaleProductId",
                principalTable: "SaleProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SaleProducts_SaleProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SaleProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaleProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleProductId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "ContactInfo",
                columns: new[] { "Id", "Email", "PhoneNumber" },
                values: new object[] { 1, "fruit@mail.com", "+9941234567" });
        }
    }
}
