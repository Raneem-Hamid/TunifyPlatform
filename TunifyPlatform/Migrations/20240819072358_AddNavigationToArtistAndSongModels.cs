using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationToArtistAndSongModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_song_Artist_ID",
                table: "song",
                column: "Artist_ID");

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_Song_ID",
                table: "playlistSongs",
                column: "Song_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlist_Playlist_ID",
                table: "playlistSongs",
                column: "Playlist_ID",
                principalTable: "playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_song_Song_ID",
                table: "playlistSongs",
                column: "Song_ID",
                principalTable: "song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_song_artist_Artist_ID",
                table: "song",
                column: "Artist_ID",
                principalTable: "artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlist_Playlist_ID",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_song_Song_ID",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_song_artist_Artist_ID",
                table: "song");

            migrationBuilder.DropIndex(
                name: "IX_song_Artist_ID",
                table: "song");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_Song_ID",
                table: "playlistSongs");

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
    }
}
