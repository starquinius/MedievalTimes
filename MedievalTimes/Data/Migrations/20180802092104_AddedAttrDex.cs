using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class AddedAttrDex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dexterity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Dex = table.Column<int>(nullable: false),
                    ReactionAdj = table.Column<int>(nullable: false),
                    MissileAttackAdj = table.Column<int>(nullable: false),
                    DefensiveAdj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dexterity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dexterity");
        }
    }
}
