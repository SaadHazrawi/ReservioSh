using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "CountPaitentAccepte", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 10, false, "Heart Clinic" },
                    { 2, 5, false, "Children's Clinic" },
                    { 3, 8, false, "Eye Clinic" },
                    { 4, 12, false, "Ear, Nose and Throat Clinic" },
                    { 5, 15, false, "Dermatology Clinic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
