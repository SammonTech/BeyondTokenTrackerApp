using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addAwardFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PointTransaction_AwardFromId",
                table: "PointTransaction",
                column: "AwardFromId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTransaction_AwardToId",
                table: "PointTransaction",
                column: "AwardToId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointTransaction_AwardFromId",
                table: "PointTransaction",
                column: "AwardFromId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PointTransaction_AwardToId",
                table: "PointTransaction",
                column: "AwardToId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointTransaction_AwardFromId",
                table: "PointTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_PointTransaction_AwardToId",
                table: "PointTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PointTransaction_AwardFromId",
                table: "PointTransaction");

            migrationBuilder.DropIndex(
                name: "IX_PointTransaction_AwardToId",
                table: "PointTransaction");
        }
    }
}
