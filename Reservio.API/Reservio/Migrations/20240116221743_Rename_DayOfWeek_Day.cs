using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class Rename_DayOfWeek_Day : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Vacations",
                newName: "Day");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Schedules",
                newName: "Day");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 6, 17, 42, 976, DateTimeKind.Local).AddTicks(6241) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 8, 17, 42, 976, DateTimeKind.Local).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 5, 17, 42, 976, DateTimeKind.Local).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 11, 17, 42, 976, DateTimeKind.Local).AddTicks(6292) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 2, 17, 42, 976, DateTimeKind.Local).AddTicks(6299) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 11, 17, 42, 976, DateTimeKind.Local).AddTicks(6307) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 3, 17, 42, 976, DateTimeKind.Local).AddTicks(6313) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Vacations",
                newName: "DayOfWeek");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Schedules",
                newName: "DayOfWeek");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 7, 48, 52, 678, DateTimeKind.Local).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 9, 48, 52, 678, DateTimeKind.Local).AddTicks(2977) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 6, 48, 52, 678, DateTimeKind.Local).AddTicks(2992) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 12, 48, 52, 678, DateTimeKind.Local).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 3, 48, 52, 678, DateTimeKind.Local).AddTicks(3023) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 12, 48, 52, 678, DateTimeKind.Local).AddTicks(3042) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 4, 48, 52, 678, DateTimeKind.Local).AddTicks(3058) });
        }
    }
}
