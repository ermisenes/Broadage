using Microsoft.EntityFrameworkCore.Migrations;

namespace BroadageData.Migrations
{
    public partial class ne3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "HomeTeams",
                newName: "MediumName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediumName",
                table: "HomeTeams",
                newName: "MiddleName");
        }
    }
}
