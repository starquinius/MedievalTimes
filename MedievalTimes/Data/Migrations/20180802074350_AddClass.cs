using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class AddClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XpLeveling",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    XpNeededLvl1 = table.Column<int>(nullable: false),
                    XpNeededLvl2 = table.Column<int>(nullable: false),
                    XpNeededLvl3 = table.Column<int>(nullable: false),
                    XpNeededLvl4 = table.Column<int>(nullable: false),
                    XpNeededLvl5 = table.Column<int>(nullable: false),
                    XpNeededLvl6 = table.Column<int>(nullable: false),
                    XpNeededLvl7 = table.Column<int>(nullable: false),
                    XpNeededLvl8 = table.Column<int>(nullable: false),
                    XpNeededLvl9 = table.Column<int>(nullable: false),
                    XpNeededLvl10 = table.Column<int>(nullable: false),
                    XpNeededLvl11 = table.Column<int>(nullable: false),
                    XpNeededLvl12 = table.Column<int>(nullable: false),
                    XpNeededLvl13 = table.Column<int>(nullable: false),
                    XpNeededLvl14 = table.Column<int>(nullable: false),
                    XpNeededLvl15 = table.Column<int>(nullable: false),
                    XpNeededLvl16 = table.Column<int>(nullable: false),
                    XpNeededLvl17 = table.Column<int>(nullable: false),
                    XpNeededLvl18 = table.Column<int>(nullable: false),
                    XpNeededLvl19 = table.Column<int>(nullable: false),
                    XpNeededLvl20 = table.Column<int>(nullable: false),
                    XpNeededMax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XpLeveling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    XpLevelingId = table.Column<Guid>(nullable: true),
                    HitDiceNr = table.Column<int>(nullable: false),
                    HitDiceSide = table.Column<int>(nullable: false),
                    HitDiceMaxLvl = table.Column<int>(nullable: false),
                    HitDiceMaxLvlModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_XpLeveling_XpLevelingId",
                        column: x => x.XpLevelingId,
                        principalTable: "XpLeveling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_XpLevelingId",
                table: "Classes",
                column: "XpLevelingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "XpLeveling");
        }
    }
}
