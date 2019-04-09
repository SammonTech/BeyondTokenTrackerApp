using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class b040819 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "PointTransactionType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PointTransactionType_RoleId",
                table: "PointTransactionType",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointTransactionType_Role",
                table: "PointTransactionType",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointTransactionType_Role",
                table: "PointTransactionType");

            migrationBuilder.DropIndex(
                name: "IX_PointTransactionType_RoleId",
                table: "PointTransactionType");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "PointTransactionType");
        }
    }
}
