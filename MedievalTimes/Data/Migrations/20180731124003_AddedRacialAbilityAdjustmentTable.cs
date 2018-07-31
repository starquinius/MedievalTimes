using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class AddedRacialAbilityAdjustmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RacialAttrReq",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RaceId = table.Column<Guid>(nullable: true),
                    MinStr = table.Column<int>(nullable: false),
                    MaxStr = table.Column<int>(nullable: false),
                    StrModifier = table.Column<int>(nullable: false),
                    MinDex = table.Column<int>(nullable: false),
                    MaxDex = table.Column<int>(nullable: false),
                    DexModifier = table.Column<int>(nullable: false),
                    MinCon = table.Column<int>(nullable: false),
                    MaxCon = table.Column<int>(nullable: false),
                    ConModifier = table.Column<int>(nullable: false),
                    MinInt = table.Column<int>(nullable: false),
                    MaxInt = table.Column<int>(nullable: false),
                    IntModifier = table.Column<int>(nullable: false),
                    MinWis = table.Column<int>(nullable: false),
                    MaxWis = table.Column<int>(nullable: false),
                    WisModifier = table.Column<int>(nullable: false),
                    MinCha = table.Column<int>(nullable: false),
                    MaxCha = table.Column<int>(nullable: false),
                    ChaModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacialAttrReq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacialAttrReq_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RacialAttrReq_RaceId",
                table: "RacialAttrReq",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RacialAttrReq");
        }
    }
}
