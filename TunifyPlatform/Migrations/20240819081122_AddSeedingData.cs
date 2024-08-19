using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "album",
                columns: new[] { "Id", "Album_Name", "Artist_ID", "Release_Date" },
                values: new object[,]
                {
                    { 1, "Album 1", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Album 2", 2, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Album 3", 3, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "artist",
                columns: new[] { "Id", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Bio for Artist 1", "Artist 1" },
                    { 2, "Bio for Artist 2", "Artist 2" },
                    { 3, "Bio for Artist 3", "Artist 3" }
                });

            migrationBuilder.InsertData(
                table: "playlist",
                columns: new[] { "Id", "Created_Date", "PlayList_Name", "User_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 19, 11, 11, 22, 593, DateTimeKind.Local).AddTicks(4019), "Playlist 1", 1 },
                    { 2, new DateTime(2024, 8, 19, 11, 11, 22, 593, DateTimeKind.Local).AddTicks(4021), "Playlist 2", 2 },
                    { 3, new DateTime(2024, 8, 19, 11, 11, 22, 593, DateTimeKind.Local).AddTicks(4022), "Playlist 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "supscribtion",
                columns: new[] { "Id", "Type", "price" },
                values: new object[,]
                {
                    { 1, "Free", "0" },
                    { 2, "Premium", "9.99m" },
                    { 3, "Family", "14.99m" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[,]
                {
                    { 1, "user1@example.com", new DateTime(2024, 8, 19, 11, 11, 22, 593, DateTimeKind.Local).AddTicks(3934), 1, "user1" },
                    { 2, "user2@example.com", new DateTime(2024, 8, 19, 11, 11, 22, 593, DateTimeKind.Local).AddTicks(3951), 2, "user2" },
                    { 3, "user3@example.com", new DateTime(2024, 8, 19, 11, 11, 22, 593, DateTimeKind.Local).AddTicks(3952), 3, "user3" }
                });

            migrationBuilder.InsertData(
                table: "song",
                columns: new[] { "Id", "Album_ID", "Artist_ID", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 3, 45, 0), "Pop", "Song 1" },
                    { 2, 2, 2, new TimeSpan(0, 0, 3, 45, 0), "Rock", "Song 2" },
                    { 3, 3, 3, new TimeSpan(0, 0, 3, 45, 0), "Jazz", "Song 3" }
                });

            migrationBuilder.InsertData(
                table: "playlistSongs",
                columns: new[] { "Playlist_ID", "Song_ID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "album",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "album",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "album",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_ID", "Song_ID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_ID", "Song_ID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_ID", "Song_ID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "supscribtion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "supscribtion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "supscribtion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "playlist",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "song",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "song",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "song",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
