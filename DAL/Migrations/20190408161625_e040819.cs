using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class e040819 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Product",
                nullable: false,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Product");
        }
    }
}
