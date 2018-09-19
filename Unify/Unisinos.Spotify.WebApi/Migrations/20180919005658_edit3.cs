using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisinos.Spotify.WebApi.Migrations
{
    public partial class edit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsMusicas_Musica_MusicaId",
                table: "PlaylistsMusicas");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsMusicas_Playlists_PlaylistId",
                table: "PlaylistsMusicas");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "PlaylistsMusicas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MusicaId",
                table: "PlaylistsMusicas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsMusicas_Musica_MusicaId",
                table: "PlaylistsMusicas",
                column: "MusicaId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsMusicas_Playlists_PlaylistId",
                table: "PlaylistsMusicas",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsMusicas_Musica_MusicaId",
                table: "PlaylistsMusicas");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsMusicas_Playlists_PlaylistId",
                table: "PlaylistsMusicas");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "PlaylistsMusicas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MusicaId",
                table: "PlaylistsMusicas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsMusicas_Musica_MusicaId",
                table: "PlaylistsMusicas",
                column: "MusicaId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsMusicas_Playlists_PlaylistId",
                table: "PlaylistsMusicas",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
