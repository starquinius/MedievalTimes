using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class UpdatedCharacterforWPs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeaponProficiency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WeaponId = table.Column<Guid>(nullable: true),
                    ProficiencySlots = table.Column<int>(nullable: false),
                    CharacterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponProficiency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponProficiency_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponProficiency_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponProficiency_CharacterId",
                table: "WeaponProficiency",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponProficiency_WeaponId",
                table: "WeaponProficiency",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeaponProficiency");
        }
    }
}
