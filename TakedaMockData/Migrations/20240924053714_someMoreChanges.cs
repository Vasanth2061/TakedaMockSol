using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakedaMockDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class someMoreChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Colleagues",
                newName: "ColleagueName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColleagueName",
                table: "Colleagues",
                newName: "Name");
        }
    }
}
