using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAndSeedUserWithWorkoutPlanId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "WorkoutPlans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "f2a8c784-fd15-4d80-bbd2-5e9600d6d5f4", "ApplicationUser", "tiko@mail.ru", false, false, null, "Tiko", null, null, null, null, false, "bffcba7d-bd33-4000-aee3-e0a91b4e01bd", false, "tiko@mail.ru" });

            migrationBuilder.UpdateData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: "1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_ApplicationUserId",
                table: "WorkoutPlans",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_AspNetUsers_ApplicationUserId",
                table: "WorkoutPlans",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_AspNetUsers_ApplicationUserId",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlans_ApplicationUserId",
                table: "WorkoutPlans");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "WorkoutPlans");
        }
    }
}
