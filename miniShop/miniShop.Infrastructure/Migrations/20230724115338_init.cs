using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace miniShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Giyim" },
                    { 2, "Elektronik" },
                    { 3, "Müzik" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Bermuda", 0.10m, "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg", "Şort", 250m },
                    { 2, 2, "Dell", 0.10m, "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg", "Laptop ", 60000m },
                    { 3, 3, "Davul seti", 0.10m, "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg", "Davul", 12000m },
                    { 4, 1, "V Yaka", 0.10m, "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg", "Tişört", 250m },
                    { 5, 1, "Blazor", 0.10m, "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg", "Ceket", 250m },
                    { 6, 1, "Top Crop", 0.10m, "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg", "Top Crop", 250m },
                    { 7, 1, "Insta-tihgt", 0.10m, "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg", "Tayt", 250m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
