using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class AddedRaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dice",
                columns: table => new
                {
                    DiceId = table.Column<Guid>(nullable: false),
                    NrDice = table.Column<int>(nullable: false),
                    DiceSide = table.Column<int>(nullable: false),
                    Modifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dice", x => x.DiceId);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BaseHeightM = table.Column<int>(nullable: false),
                    BaseHeightF = table.Column<int>(nullable: false),
                    HeightModifierDiceId = table.Column<Guid>(nullable: true),
                    BaseWeightM = table.Column<int>(nullable: false),
                    BaseWeightF = table.Column<int>(nullable: false),
                    WeightModifierDiceId = table.Column<Guid>(nullable: true),
                    BaseAge = table.Column<int>(nullable: false),
                    AgeModifierDiceId = table.Column<Guid>(nullable: true),
                    BaseMaxAge = table.Column<int>(nullable: false),
                    MaxAgeModifierDiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                    table.ForeignKey(
                        name: "FK_Races_Dice_AgeModifierDiceId",
                        column: x => x.AgeModifierDiceId,
                        principalTable: "Dice",
                        principalColumn: "DiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_Dice_HeightModifierDiceId",
                        column: x => x.HeightModifierDiceId,
                        principalTable: "Dice",
                        principalColumn: "DiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_Dice_MaxAgeModifierDiceId",
                        column: x => x.MaxAgeModifierDiceId,
                        principalTable: "Dice",
                        principalColumn: "DiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_Dice_WeightModifierDiceId",
                        column: x => x.WeightModifierDiceId,
                        principalTable: "Dice",
                        principalColumn: "DiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_AgeModifierDiceId",
                table: "Races",
                column: "AgeModifierDiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_HeightModifierDiceId",
                table: "Races",
                column: "HeightModifierDiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_MaxAgeModifierDiceId",
                table: "Races",
                column: "MaxAgeModifierDiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_WeightModifierDiceId",
                table: "Races",
                column: "WeightModifierDiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Dice");
        }
    }
}
