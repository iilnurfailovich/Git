using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class IsTakeBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTake",
                table: "Book",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTake",
                table: "Book");
        }
    }
}
