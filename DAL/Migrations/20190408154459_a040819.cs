using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class a040819 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectOnTransaction",
                table: "Product");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Product",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PointTransaction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AwardToId",
                table: "PointTransaction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwardFromId",
                table: "PointTransaction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointTransactionTypeId",
                table: "PointTransaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PointTransactionType",
                columns: table => new
                {
                    PointTransactionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AffectOnTransaction = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTransactionType", x => x.PointTransactionTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointTransaction_PointTransactionTypeId",
                table: "PointTransaction",
                column: "PointTransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTransactionType_Name",
                table: "PointTransactionType",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PointTransaction_PointTransactionType",
                table: "PointTransaction",
                column: "PointTransactionTypeId",
                principalTable: "PointTransactionType",
                principalColumn: "PointTransactionTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointTransaction_PointTransactionType",
                table: "PointTransaction");

            migrationBuilder.DropTable(
                name: "PointTransactionType");

            migrationBuilder.DropIndex(
                name: "IX_PointTransaction_PointTransactionTypeId",
                table: "PointTransaction");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PointTransactionTypeId",
                table: "PointTransaction");

            migrationBuilder.AddColumn<int>(
                name: "AffectOnTransaction",
                table: "Product",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PointTransaction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwardToId",
                table: "PointTransaction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AwardFromId",
                table: "PointTransaction",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
