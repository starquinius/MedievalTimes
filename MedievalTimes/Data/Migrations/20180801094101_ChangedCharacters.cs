using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedievalTimes.Data.Migrations
{
    public partial class ChangedCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildId",
                table: "Characters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuildId",
                table: "Characters",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
