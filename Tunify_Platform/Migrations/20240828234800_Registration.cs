using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class Registration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumID",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 29, 2, 48, 0, 551, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 2, 48, 0, 551, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 2, 48, 0, 551, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 29, 2, 48, 0, 551, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 29, 2, 48, 0, 551, DateTimeKind.Local).AddTicks(6840));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumID",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 29, 0, 36, 8, 43, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 0, 36, 8, 43, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 0, 36, 8, 43, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 29, 0, 36, 8, 43, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 29, 0, 36, 8, 43, DateTimeKind.Local).AddTicks(7690));
        }
    }
}
