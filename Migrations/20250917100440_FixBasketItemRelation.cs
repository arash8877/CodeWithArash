using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithArash.Migrations
{
  /// <inheritdoc />
  public partial class FixBasketItemRelation : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Products",
          columns: table => new
          {
            Id = table.Column<int>(type: "INTEGER", nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(type: "TEXT", nullable: false),
            Description = table.Column<string>(type: "TEXT", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Products", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "BasketItems",
          columns: table => new
          {
            Id = table.Column<int>(type: "INTEGER", nullable: false),
            Price = table.Column<decimal>(type: "TEXT", nullable: false),
            QuantityInStock = table.Column<int>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_BasketItems", x => x.Id);
            table.ForeignKey(
                      name: "FK_BasketItems_Products_Id",
                      column: x => x.Id,
                      principalTable: "Products",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ProductInCategories",
          columns: table => new
          {
            ProductId = table.Column<int>(type: "INTEGER", nullable: false),
            CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ProductInCategories", x => new { x.ProductId, x.CategoryId });
            table.ForeignKey(
                      name: "FK_ProductInCategories_Categories_CategoryId",
                      column: x => x.CategoryId,
                      principalTable: "Categories",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ProductInCategories_Products_ProductId",
                      column: x => x.ProductId,
                      principalTable: "Products",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_ProductInCategories_CategoryId",
          table: "ProductInCategories",
          column: "CategoryId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "BasketItems");

      migrationBuilder.DropTable(
          name: "ProductInCategories");

      migrationBuilder.DropTable(
          name: "Products");
    }
  }
}
