using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class change_in_Patient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Patients_PatientId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PatientId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date", "Gender" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2732), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date", "Gender" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 21, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2772), 2 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date", "Gender" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 18, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2779), 2 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date", "Gender" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 21, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2787), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date", "Gender" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2795), 2 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date", "Gender" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2804), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date", "Gender" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 20, 22, 33, 34, 741, DateTimeKind.Local).AddTicks(2811), 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookFor", "Date", "Gender", "PatientId" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 15, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9217), 0, null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "BookFor", "Date", "Gender", "PatientId" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9263), 1, null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "BookFor", "Date", "Gender", "PatientId" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 16, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9276), 1, null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                columns: new[] { "BookFor", "Date", "Gender", "PatientId" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 19, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9289), 0, null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                columns: new[] { "BookFor", "Date", "Gender", "PatientId" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9301), 1, null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6,
                columns: new[] { "BookFor", "Date", "Gender", "PatientId" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 17, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9313), 0, null });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7,
                columns: new[] { "BookFor", "Date", "Gender", "PatientId" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 18, 6, 29, 32, 686, DateTimeKind.Local).AddTicks(9325), 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PatientId",
                table: "Reservations",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Patients_PatientId",
                table: "Reservations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }
    }
}
