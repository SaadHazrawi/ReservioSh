using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosptil.Migrations
{
    /// <inheritdoc />
    public partial class fixNvegationProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Substitutes_Patients_PatientId",
                table: "Substitutes");

            migrationBuilder.DropIndex(
                name: "IX_Substitutes_PatientId",
                table: "Substitutes");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Substitutes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Substitutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Substitutes_PatientId",
                table: "Substitutes",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Substitutes_Patients_PatientId",
                table: "Substitutes",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
