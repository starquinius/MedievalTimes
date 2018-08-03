using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class UpdatedWPs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ProficiencySlots",
                table: "WeaponProficiency",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NrSlots",
                table: "WeaponProficiency",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrSlots",
                table: "WeaponProficiency");

            migrationBuilder.AlterColumn<int>(
                name: "ProficiencySlots",
                table: "WeaponProficiency",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
