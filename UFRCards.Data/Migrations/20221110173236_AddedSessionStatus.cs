using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFRCards.Data.Migrations
{
    public partial class AddedSessionStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "GameSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameSessionSettings_MaxPlayers",
                table: "GameSessions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameSessionSettings_QuestionCategory",
                table: "GameSessions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameSessionStatus",
                table: "GameSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "GameSessionSettings_MaxPlayers",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "GameSessionSettings_QuestionCategory",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "GameSessionStatus",
                table: "GameSessions");
        }
    }
}
