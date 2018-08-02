using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class AddedAttrStr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strength",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Str = table.Column<int>(nullable: false),
                    StrMinP = table.Column<int>(nullable: false),
                    StrMaxP = table.Column<int>(nullable: false),
                    HitProb = table.Column<int>(nullable: false),
                    DmgAdj = table.Column<int>(nullable: false),
                    WeightAllow = table.Column<int>(nullable: false),
                    MaxPress = table.Column<int>(nullable: false),
                    OpenDoors = table.Column<int>(nullable: false),
                    OpenClosedDoors = table.Column<int>(nullable: false),
                    BendBarsLiftGates = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strength", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strength");
        }
    }
}
