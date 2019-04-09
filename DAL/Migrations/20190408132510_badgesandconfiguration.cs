using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class badgesandconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeLevel",
                table: "GroupDetail");

            migrationBuilder.RenameColumn(
                name: "BadgeImgSrc",
                table: "GroupDetail",
                newName: "ValueString");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValueDate",
                table: "GroupDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValueNumber",
                table: "GroupDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    BadgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    TokensRequired = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.BadgeId);
                    table.ForeignKey(
                        name: "FK_Badge_Group",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    ConfigurationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    ValueNumber = table.Column<int>(nullable: true),
                    ValueString = table.Column<string>(nullable: true),
                    ValueDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.ConfigurationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badge_GroupId",
                table: "Badge",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Name",
                table: "Configuration",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropColumn(
                name: "ValueDate",
                table: "GroupDetail");

            migrationBuilder.DropColumn(
                name: "ValueNumber",
                table: "GroupDetail");

            migrationBuilder.RenameColumn(
                name: "ValueString",
                table: "GroupDetail",
                newName: "BadgeImgSrc");

            migrationBuilder.AddColumn<int>(
                name: "BadgeLevel",
                table: "GroupDetail",
                nullable: false,
                defaultValue: 0);
        }
    }
}
