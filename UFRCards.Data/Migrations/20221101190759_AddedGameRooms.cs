using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UFRCards.Data.Migrations
{
    public partial class AddedGameRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameRoomId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Answers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    GameRoomSettings_UsersCount = table.Column<int>(type: "integer", nullable: true),
                    GameRoomSettings_MaxRounds = table.Column<int>(type: "integer", nullable: true),
                    GameRoomSettings_RoundsPassed = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    GameRoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_GameRooms_GameRoomId",
                        column: x => x.GameRoomId,
                        principalTable: "GameRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GameRoomId",
                table: "Questions",
                column: "GameRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_PlayerId",
                table: "Answers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameRoomId",
                table: "Player",
                column: "GameRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Player_PlayerId",
                table: "Answers",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_GameRooms_GameRoomId",
                table: "Questions",
                column: "GameRoomId",
                principalTable: "GameRooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Player_PlayerId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_GameRooms_GameRoomId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "GameRooms");

            migrationBuilder.DropIndex(
                name: "IX_Questions_GameRoomId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_PlayerId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "GameRoomId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Answers");
        }
    }
}
