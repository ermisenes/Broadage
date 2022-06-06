using Microsoft.EntityFrameworkCore.Migrations;

namespace BroadageData.Migrations
{
    public partial class ne1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EextraTime",
                table: "Scores",
                newName: "ExtraTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExtraTime",
                table: "Scores",
                newName: "EextraTime");
        }
    }
}
