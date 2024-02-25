using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIPAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 20, 12, 16, 23, 504, DateTimeKind.Local).AddTicks(5302) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 12, 16, 23, 504, DateTimeKind.Local).AddTicks(5333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 21, 12, 16, 23, 504, DateTimeKind.Local).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 24, 12, 16, 23, 504, DateTimeKind.Local).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 22, 12, 16, 23, 504, DateTimeKind.Local).AddTicks(5348) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 22, 12, 16, 23, 504, DateTimeKind.Local).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 23, 12, 16, 23, 504, DateTimeKind.Local).AddTicks(5359) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "IPAddress",
                value: "192.168.0.1");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "IPAddress",
                value: "192.168.0.2");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "IPAddress",
                value: "192.168.0.3");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4,
                column: "IPAddress",
                value: "192.168.0.4");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 5,
                column: "IPAddress",
                value: "192.168.0.5");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 21, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 18, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4878) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 21, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4884) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 20, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4900) });
        }
    }
}
