using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeWithArash.Migrations
{
  /// <inheritdoc />
  public partial class SeedCategoryData : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "Categories",
          columns: new[] { "Id", "Description", "Name" },
          values: new object[,]
          {
                    { 1, "All about ASP .NET Core and C# programming", "ASP .NET Core 9" },
                    { 2, "All about JavaScript programming", "JavaScript" },
                    { 3, "All about Python programming", "Python" },
                    { 4, "All about Machine Learning", "Machine Learning" }
          });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "Categories",
          keyColumn: "Id",
          keyValue: 1);

      migrationBuilder.DeleteData(
          table: "Categories",
          keyColumn: "Id",
          keyValue: 2);

      migrationBuilder.DeleteData(
          table: "Categories",
          keyColumn: "Id",
          keyValue: 3);

      migrationBuilder.DeleteData(
          table: "Categories",
          keyColumn: "Id",
          keyValue: 4);
    }
  }
}
