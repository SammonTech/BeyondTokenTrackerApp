using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class d040819 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AffectOnTransaction",
                table: "PointTransactionType",
                newName: "AffectOnAwardTo");

            migrationBuilder.AddColumn<int>(
                name: "AffectOnAwardFrom",
                table: "PointTransactionType",
                nullable: false,
                defaultValueSql: "((1))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectOnAwardFrom",
                table: "PointTransactionType");

            migrationBuilder.RenameColumn(
                name: "AffectOnAwardTo",
                table: "PointTransactionType",
                newName: "AffectOnTransaction");
        }
    }
}
