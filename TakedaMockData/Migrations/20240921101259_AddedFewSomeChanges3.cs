using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakedaMockDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedFewSomeChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleagues_Members_MemberId",
                table: "Colleagues");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingActivities_Members_MemberId",
                table: "TrainingActivities");

            migrationBuilder.DropIndex(
                name: "IX_TrainingActivities_MemberId",
                table: "TrainingActivities");

            migrationBuilder.DropIndex(
                name: "IX_Colleagues_MemberId",
                table: "Colleagues");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "TrainingActivities");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Colleagues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "TrainingActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Colleagues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Colleagues",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainingActivities",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingActivities_MemberId",
                table: "TrainingActivities",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_MemberId",
                table: "Colleagues",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleagues_Members_MemberId",
                table: "Colleagues",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingActivities_Members_MemberId",
                table: "TrainingActivities",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
