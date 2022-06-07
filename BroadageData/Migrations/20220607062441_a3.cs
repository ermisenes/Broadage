using Microsoft.EntityFrameworkCore.Migrations;

namespace BroadageData.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "MatchId",
               table: "Matches",
               type: "int",
               nullable: false);
        }
    }
}
