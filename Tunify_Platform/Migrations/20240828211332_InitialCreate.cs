using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumID",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 29, 0, 13, 32, 605, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 0, 13, 32, 605, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 0, 13, 32, 605, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 29, 0, 13, 32, 605, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 29, 0, 13, 32, 605, DateTimeKind.Local).AddTicks(7330));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumID",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 27, 22, 34, 38, 566, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 22, 34, 38, 566, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 22, 34, 38, 566, DateTimeKind.Local).AddTicks(9840));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2024, 8, 27, 22, 34, 38, 566, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2024, 8, 27, 22, 34, 38, 566, DateTimeKind.Local).AddTicks(9620));
        }
    }
}
