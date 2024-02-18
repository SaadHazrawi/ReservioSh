using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class Change_Regoin_to_Region : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Regoin",
                table: "Reservations",
                newName: "Region");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Reservations",
                newName: "Regoin");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 13, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 17, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 14, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 17, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 15, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 15, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 16, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9856));
        }
    }
}
