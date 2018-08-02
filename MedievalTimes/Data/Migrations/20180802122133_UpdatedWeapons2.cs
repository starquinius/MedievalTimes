using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class UpdatedWeapons2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ROF",
                table: "Weapons",
                newName: "ROFrnd");

            migrationBuilder.AddColumn<int>(
                name: "ROFnr",
                table: "Weapons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ROFnr",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "ROFrnd",
                table: "Weapons",
                newName: "ROF");
        }
    }
}
