using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcceptedPatientsCount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.ClinicId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.VacationId);
                    table.ForeignKey(
                        name: "FK_Vacations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Regoin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookFor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "AcceptedPatientsCount", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 10, false, "Heart Clinic" },
                    { 2, 5, false, "Children's Clinic" },
                    { 3, 8, false, "Eye Clinic" },
                    { 4, 12, false, "Ear, Nose and Throat Clinic" },
                    { 5, 15, false, "Dermatology Clinic" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "FullName", "IsDeleted", "Specialist" },
                values: new object[,]
                {
                    { 1, "Dr. Smith", false, "Cardiology" },
                    { 2, "Dr. Johnson", false, "Cardiology" },
                    { 3, "Dr. Williams", false, "Pediatrics" },
                    { 4, "Dr. Brown", false, "Pediatrics" },
                    { 5, "Dr. Jones", false, "Ophthalmology" },
                    { 6, "Dr. Davis", false, "Ophthalmology" },
                    { 7, "Dr. Miller", false, "ENT" },
                    { 8, "Dr. Wilson", false, "ENT" },
                    { 9, "Dr. Moore", false, "Dermatology" },
                    { 10, "Dr. Taylor", false, "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "BookFor", "ClinicId", "Date", "DateOfBirth", "FirstName", "Gender", "IPAddress", "IsDeleted", "LastName", "PatientId", "PhoneNumber", "Regoin" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 2, 13, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9788), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdullah", 0, "192.168.0.1", false, "Doe", null, "1234567890", "Reason for reservation 1" },
                    { 2, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2024, 2, 17, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9828), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar", 1, "192.168.0.2", false, "Doe", null, "9876543210", "Reason for reservation 2" },
                    { 3, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2024, 2, 14, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9834), new DateTime(1982, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saad", 1, "192.168.0.3", false, "Smith", null, "5551234567", "Reason for reservation 3" },
                    { 4, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2024, 2, 17, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9839), new DateTime(1975, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ammar", 0, "192.168.0.4", false, "Johnson", null, "3339876543", "Reason for reservation 4" },
                    { 5, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2024, 2, 15, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9844), new DateTime(1988, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", 1, "192.168.0.5", false, "Anderson", null, "1112223333", "Reason for reservation 5" },
                    { 6, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 2, 15, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9851), new DateTime(1978, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 0, "192.168.0.6", false, "Clark", null, "9998887777", "Reason for reservation 6" },
                    { 7, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2024, 2, 16, 12, 21, 50, 696, DateTimeKind.Local).AddTicks(9856), new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", 1, "192.168.0.7", false, "Brown", null, "7775558888", "Reason for reservation 7" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "ClinicId", "Day", "DoctorId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, false },
                    { 2, 1, 2, 2, false },
                    { 3, 2, 3, 3, false },
                    { 4, 3, 4, 4, false },
                    { 5, 3, 5, 5, false },
                    { 6, 4, 6, 6, false },
                    { 7, 4, 0, 7, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClinicId",
                table: "Reservations",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PatientId",
                table: "Reservations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClinicId",
                table: "Schedules",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_DoctorId",
                table: "Vacations",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
