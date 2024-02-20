using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class Change_IsDelete_to_PatientVisitReviewed_in_Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Reservations",
                newName: "PatientVisitReviewed");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 15, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9217) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9263) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 16, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 18, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9325) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientVisitReviewed",
                table: "Reservations",
                newName: "IsDeleted");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 14, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3158) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 18, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3199) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 15, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3215) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 18, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 16, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 16, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 1, 37, 49, 405, DateTimeKind.Local).AddTicks(3282) });
        }
    }
}
