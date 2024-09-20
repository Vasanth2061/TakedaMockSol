using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakedaMockDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedAndSeededMemberData : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackGround = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnivEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hobbies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tegnologies = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BackGround", "City", "DateOfBirth", "Hobbies", "Name", "PhoneNumber", "PinCode", "State", "StreetAddress", "Tegnologies", "UnivEducation" },
                values: new object[] { 1, "A 2024 Graduate working in Deloitte for 2 months", "Bangalore", new DateOnly(2002, 2, 21), "[\"Cricket\",\"Light Novels\"]", "Vasanth M", "7975110608", "560057", "Karnataka", "No 439, Vasanth Nilayam,3rd cross, Prakruti Badavane layout, Anchepalya", "[\"C#\",\"SQL Server\",\"HTML\",\"CSS\",\"JavaScript\"]", "Btech ECE, NITK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
