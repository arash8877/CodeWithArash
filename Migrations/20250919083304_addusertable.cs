using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithArash.Migrations
{
  /// <inheritdoc />
  public partial class addusertable : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            UserId = table.Column<int>(type: "INTEGER", nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Email = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
            Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
            RegisterTime = table.Column<DateTime>(type: "TEXT", nullable: false),
            IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.UserId);
          });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Users");
    }
  }
}
