using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class UpdatedClassAbilityReqTableWithoutList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_ClassAttrReq_ClassAbilityRequirementsId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_ClassAbilityRequirementsId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "ClassAbilityRequirementsId",
                table: "Races");

            migrationBuilder.AddColumn<bool>(
                name: "RaceDwarf",
                table: "ClassAttrReq",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RaceElf",
                table: "ClassAttrReq",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RaceGnome",
                table: "ClassAttrReq",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RaceHalfElf",
                table: "ClassAttrReq",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RaceHalfling",
                table: "ClassAttrReq",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RaceHuman",
                table: "ClassAttrReq",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaceDwarf",
                table: "ClassAttrReq");

            migrationBuilder.DropColumn(
                name: "RaceElf",
                table: "ClassAttrReq");

            migrationBuilder.DropColumn(
                name: "RaceGnome",
                table: "ClassAttrReq");

            migrationBuilder.DropColumn(
                name: "RaceHalfElf",
                table: "ClassAttrReq");

            migrationBuilder.DropColumn(
                name: "RaceHalfling",
                table: "ClassAttrReq");

            migrationBuilder.DropColumn(
                name: "RaceHuman",
                table: "ClassAttrReq");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassAbilityRequirementsId",
                table: "Races",
                nullable: true);

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
    }
}
