using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGDatabase.Migrations
{
    public partial class monster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonsterId",
                table: "ItemCtrl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MonsterSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatsId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ExperienceLvl = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    Pv = table.Column<int>(type: "int", nullable: false),
                    PvMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterSet_CharacterStat_StatsId",
                        column: x => x.StatsId,
                        principalTable: "CharacterStat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCtrl_MonsterId",
                table: "ItemCtrl",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSet_StatsId",
                table: "MonsterSet",
                column: "StatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCtrl_MonsterSet_MonsterId",
                table: "ItemCtrl",
                column: "MonsterId",
                principalTable: "MonsterSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCtrl_MonsterSet_MonsterId",
                table: "ItemCtrl");

            migrationBuilder.DropTable(
                name: "MonsterSet");

            migrationBuilder.DropIndex(
                name: "IX_ItemCtrl_MonsterId",
                table: "ItemCtrl");

            migrationBuilder.DropColumn(
                name: "MonsterId",
                table: "ItemCtrl");
        }
    }
}
