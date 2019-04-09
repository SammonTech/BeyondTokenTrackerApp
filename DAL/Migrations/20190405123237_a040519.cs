using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class a040519 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "User");
        }
    }
}
