using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationToPlaylistSongModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_PlaylistId",
                table: "playlistSongs",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_SongId",
                table: "playlistSongs",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlist_PlaylistId",
                table: "playlistSongs",
                column: "PlaylistId",
                principalTable: "playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_song_SongId",
                table: "playlistSongs",
                column: "SongId",
                principalTable: "song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlist_PlaylistId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_song_SongId",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_PlaylistId",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_SongId",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "playlistSongs");
        }
    }
}
