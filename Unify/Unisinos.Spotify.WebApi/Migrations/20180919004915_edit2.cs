using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisinos.Spotify.WebApi.Migrations
{
    public partial class edit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistMusica_Musica_MusicaId",
                table: "PlaylistMusica");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistMusica_Playlists_PlaylistId",
                table: "PlaylistMusica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistMusica",
                table: "PlaylistMusica");

            migrationBuilder.RenameTable(
                name: "PlaylistMusica",
                newName: "PlaylistsMusicas");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistMusica_PlaylistId",
                table: "PlaylistsMusicas",
                newName: "IX_PlaylistsMusicas_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistMusica_MusicaId",
                table: "PlaylistsMusicas",
                newName: "IX_PlaylistsMusicas_MusicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistsMusicas",
                table: "PlaylistsMusicas",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsMusicas_Musica_MusicaId",
                table: "PlaylistsMusicas");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsMusicas_Playlists_PlaylistId",
                table: "PlaylistsMusicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistsMusicas",
                table: "PlaylistsMusicas");

            migrationBuilder.RenameTable(
                name: "PlaylistsMusicas",
                newName: "PlaylistMusica");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistsMusicas_PlaylistId",
                table: "PlaylistMusica",
                newName: "IX_PlaylistMusica_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistsMusicas_MusicaId",
                table: "PlaylistMusica",
                newName: "IX_PlaylistMusica_MusicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistMusica",
                table: "PlaylistMusica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistMusica_Musica_MusicaId",
                table: "PlaylistMusica",
                column: "MusicaId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistMusica_Playlists_PlaylistId",
                table: "PlaylistMusica",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
