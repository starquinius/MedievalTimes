using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class UpdatedWeapons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SpeedFactor = table.Column<int>(nullable: false),
                    DamageSMnrDice = table.Column<int>(nullable: false),
                    DamageSMDiceSide = table.Column<int>(nullable: false),
                    DamageSAdj = table.Column<int>(nullable: false),
                    DamageLnrDice = table.Column<int>(nullable: false),
                    DamageLDiceSide = table.Column<int>(nullable: false),
                    DamageLAdj = table.Column<int>(nullable: false),
                    ROF = table.Column<int>(nullable: false),
                    RangeS = table.Column<int>(nullable: false),
                    RangeM = table.Column<int>(nullable: false),
                    RangeL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
