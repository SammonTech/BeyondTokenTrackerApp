using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class b040419 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BadgeLevel",
                table: "GroupDetail",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeLevel",
                table: "GroupDetail");
        }
    }
}
