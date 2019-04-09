using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class a040419 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectOnTransaction",
                table: "ProductGroup");

            migrationBuilder.AddColumn<int>(
                name: "AffectOnTransaction",
                table: "Product",
                nullable: false,
                defaultValueSql: "((1))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectOnTransaction",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "AffectOnTransaction",
                table: "ProductGroup",
                nullable: false,
                defaultValueSql: "((1))");
        }
    }
}
