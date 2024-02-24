using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "DateOfBirth", "FirstName", "Gender", "IPAddress", "IsDeleted", "LastName", "Region" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdullah", 1, "192.168.0.1", false, "Doe", "Region 1" },
                    { 2, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar", 2, "192.168.0.2", false, "Doe", "Region 2" },
                    { 3, new DateTime(1978, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 1, "192.168.0.3", false, "Smith", "Region 3" },
                    { 4, new DateTime(1992, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", 2, "192.168.0.4", false, "Johnson", "Region 4" },
                    { 5, new DateTime(1980, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 1, "192.168.0.5", false, "Brown", "Region 5" }
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 17, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 21, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 18, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 21, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 19, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 19, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 20, 23, 5, 30, 464, DateTimeKind.Local).AddTicks(4900));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 17, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 21, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 18, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 21, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 19, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 19, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 20, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2811));
        }
    }
}
