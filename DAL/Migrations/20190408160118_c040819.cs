using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class c040819 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PointTransactionType_Name",
                table: "PointTransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_PointTransactionType_Name_RoleId",
                table: "PointTransactionType",
                columns: new[] { "Name", "RoleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PointTransactionType_Name_RoleId",
                table: "PointTransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_PointTransactionType_Name",
                table: "PointTransactionType",
                column: "Name",
                unique: true);
        }
    }
}
