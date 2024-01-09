using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class Rename_CountPaitentAccepte_to_CountPaitentAccepted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountPaitentAccepte",
                table: "Clinics",
                newName: "CountPaitentAccepted");

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "BookFor", "ClinicId", "Date", "DateOfBirth", "FirstName", "Gender", "IPAddress", "IsDeleted", "LastName", "PatientId", "PhoneNumber", "Resgoin" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 10, 5, 48, 54, 228, DateTimeKind.Local).AddTicks(3226), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdullah", 1, "192.168.0.1", false, "Doe", null, "1234567890", "Reason for reservation 1" },
                    { 2, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2024, 1, 10, 7, 48, 54, 228, DateTimeKind.Local).AddTicks(3260), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar", 2, "192.168.0.2", false, "Doe", null, "9876543210", "Reason for reservation 2" },
                    { 3, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2024, 1, 10, 4, 48, 54, 228, DateTimeKind.Local).AddTicks(3265), new DateTime(1982, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saad", 2, "192.168.0.3", false, "Smith", null, "5551234567", "Reason for reservation 3" },
                    { 4, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2024, 1, 10, 10, 48, 54, 228, DateTimeKind.Local).AddTicks(3271), new DateTime(1975, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ammar", 1, "192.168.0.4", false, "Johnson", null, "3339876543", "Reason for reservation 4" },
                    { 5, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2024, 1, 10, 1, 48, 54, 228, DateTimeKind.Local).AddTicks(3276), new DateTime(1988, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", 2, "192.168.0.5", false, "Anderson", null, "1112223333", "Reason for reservation 5" },
                    { 6, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 10, 10, 48, 54, 228, DateTimeKind.Local).AddTicks(3282), new DateTime(1978, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 1, "192.168.0.6", false, "Clark", null, "9998887777", "Reason for reservation 6" },
                    { 7, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2024, 1, 10, 2, 48, 54, 228, DateTimeKind.Local).AddTicks(3287), new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", 2, "192.168.0.7", false, "Brown", null, "7775558888", "Reason for reservation 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7);

            migrationBuilder.RenameColumn(
                name: "CountPaitentAccepted",
                table: "Clinics",
                newName: "CountPaitentAccepte");
        }
    }
}
