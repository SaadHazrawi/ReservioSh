using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding_Doctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 10);
        }
    }
}
