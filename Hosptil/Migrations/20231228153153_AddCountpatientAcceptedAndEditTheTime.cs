using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosptil.Migrations
{
    /// <inheritdoc />
    public partial class AddCountpatientAcceptedAndEditTheTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountPaitentAccepte",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountPaitentAccepte",
                table: "Clinics");
        }
    }
}
