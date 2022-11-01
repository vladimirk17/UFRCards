using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFRCards.Data.Migrations
{
    public partial class AddedGameRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameRoomSettings_CurrentRound",
                table: "GameRooms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameRound",
                columns: table => new
                {
                    RoundNumber = table.Column<int>(type: "integer", nullable: false),
                    GameRoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRound", x => new { x.GameRoomId, x.RoundNumber });
                    table.ForeignKey(
                        name: "FK_GameRound_GameRooms_GameRoomId",
                        column: x => x.GameRoomId,
                        principalTable: "GameRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRound");

            migrationBuilder.DropColumn(
                name: "GameRoomSettings_CurrentRound",
                table: "GameRooms");
        }
    }
}
