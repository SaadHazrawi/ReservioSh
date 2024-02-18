using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 14, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 18, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 15, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 18, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 16, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 16, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3266));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 17, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3282));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 13, 12, 33, 16, 910, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 17, 12, 33, 16, 910, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 14, 12, 33, 16, 910, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 17, 12, 33, 16, 910, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 15, 12, 33, 16, 910, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 15, 12, 33, 16, 910, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 16, 12, 33, 16, 910, DateTimeKind.Local).AddTicks(2511));
        }
    }
}
