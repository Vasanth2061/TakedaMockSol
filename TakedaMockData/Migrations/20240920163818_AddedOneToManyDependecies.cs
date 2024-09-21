using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakedaMockDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedOneToManyDependecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackGround = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UnivEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hobbies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tegnologies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colleagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTeamMemeber = table.Column<bool>(type: "bit", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colleagues_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingActivities_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BackGround", "City", "DateOfBirth", "Hobbies", "Images", "Name", "PhoneNumber", "PinCode", "State", "StreetAddress", "Tegnologies", "UnivEducation" },
                values: new object[] { 1, "A 2024 Graduate working in Deloitte for 2 months", "Bangalore", new DateOnly(2002, 2, 21), "[\"Cricket\",\"Light Novels\"]", "[\"\",\"\"]", "Vasanth M", "7975110608", "560057", "Karnataka", "No 439, Vasanth Nilayam,3rd cross, Prakruti Badavane layout, Anchepalya", "[\"C#\",\"SQL Server\",\"HTML\",\"CSS\",\"JavaScript\"]", "Btech ECE, NITK" });

            migrationBuilder.InsertData(
                table: "Colleagues",
                columns: new[] { "Id", "Description", "ImageURL", "IsTeamMemeber", "MemberId", "Name" },
                values: new object[] { 1, " Met during SPARK training. Both of us are Tamilains, so got along well", " ", true, 1, "Jeevan Krishna" });

            migrationBuilder.InsertData(
                table: "TrainingActivities",
                columns: new[] { "Id", "Description", "EndDate", "MemberId", "Name", "StartDate" },
                values: new object[] { 1, "Learnt about DDL,DML queries, the types of locks, triggers, functions and stored procedures", new DateOnly(2024, 7, 30), 1, "SQL Server Foundation-Intermediate", new DateOnly(2024, 7, 15) });

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_MemberId",
                table: "Colleagues",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingActivities_MemberId",
                table: "TrainingActivities",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colleagues");

            migrationBuilder.DropTable(
                name: "TrainingActivities");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
