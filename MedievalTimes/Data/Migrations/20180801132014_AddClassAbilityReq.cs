using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class AddClassAbilityReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassAbilityRequirementsId",
                table: "Races",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassAttrReq",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Beroep = table.Column<int>(nullable: false),
                    MinStr = table.Column<int>(nullable: false),
                    StrPrime = table.Column<bool>(nullable: false),
                    MinDex = table.Column<int>(nullable: false),
                    DexPrime = table.Column<bool>(nullable: false),
                    MinCon = table.Column<int>(nullable: false),
                    ConPrime = table.Column<bool>(nullable: false),
                    MinInt = table.Column<int>(nullable: false),
                    IntPrime = table.Column<bool>(nullable: false),
                    MinWis = table.Column<int>(nullable: false),
                    WisPrime = table.Column<bool>(nullable: false),
                    MinCha = table.Column<int>(nullable: false),
                    ChaPrime = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAttrReq", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_ClassAbilityRequirementsId",
                table: "Races",
                column: "ClassAbilityRequirementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_ClassAttrReq_ClassAbilityRequirementsId",
                table: "Races",
                column: "ClassAbilityRequirementsId",
                principalTable: "ClassAttrReq",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_ClassAttrReq_ClassAbilityRequirementsId",
                table: "Races");

            migrationBuilder.DropTable(
                name: "ClassAttrReq");

            migrationBuilder.DropIndex(
                name: "IX_Races_ClassAbilityRequirementsId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "ClassAbilityRequirementsId",
                table: "Races");
        }
    }
}
