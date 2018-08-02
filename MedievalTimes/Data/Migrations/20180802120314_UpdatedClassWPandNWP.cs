using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class UpdatedClassWPandNWP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NWPinit",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NWPperLvl",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WPinit",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WPperLvl",
                table: "Classes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NWPinit",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "NWPperLvl",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "WPinit",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "WPperLvl",
                table: "Classes");
        }
    }
}
