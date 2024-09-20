using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakedaMockDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedAndSeededTrainingActivityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingActivities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TrainingActivities",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, "Learnt about DDL,DML queries, the types of locks, triggers, functions and stored procedures", new DateOnly(2024, 7, 30), "SQL SErver Foundation-Intermediate", new DateOnly(2024, 7, 15) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingActivities");
        }
    }
}
