using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFRCards.Data.Migrations
{
    public partial class AdjustedNamingGameSessioSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameSessionSettings_UsersCount",
                table: "GameSessions",
                newName: "GameSessionSettings_PlayersCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameSessionSettings_PlayersCount",
                table: "GameSessions",
                newName: "GameSessionSettings_UsersCount");
        }
    }
}
