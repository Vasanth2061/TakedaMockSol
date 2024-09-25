using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TakedaMockDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedomeMoreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hobbies",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Tegnologies",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proficiency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Self explanatory.", "Cricket" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "Proficiency" },
                values: new object[,]
                {
                    { 1, "C#", 4 },
                    { 2, "SQL-Server", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "PersonalImages");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.AddColumn<string>(
                name: "Hobbies",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tegnologies",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Hobbies", "Images", "Tegnologies" },
                values: new object[] { "[\"Cricket\",\"Light Novels\"]", "[\"\",\"\"]", "[\"C#\",\"SQL Server\",\"HTML\",\"CSS\",\"JavaScript\"]" });
        }
    }
}
