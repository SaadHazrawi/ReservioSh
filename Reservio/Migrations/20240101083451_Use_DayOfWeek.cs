using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservio.Migrations
{
    /// <inheritdoc />
    public partial class Use_DayOfWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeekDay",
                table: "Substitutes",
                newName: "DayOfWeek");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Substitutes",
                newName: "WeekDay");
        }
    }
}
