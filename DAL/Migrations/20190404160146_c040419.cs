using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class c040419 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BadgeImgSrc",
                table: "GroupDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeImgSrc",
                table: "GroupDetail");
        }
    }
}
