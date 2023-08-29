using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedWorkoutDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutDetails",
                columns: new[] { "Id", "Muscle", "Name", "Reps", "Sets", "Weight", "WorkoutPlanId" },
                values: new object[,]
                {
                    { 1, "Back", "Deadlift", "12/10/8", 3, "60/70/80", 2 },
                    { 2, "Chest", "Chest Press", "12/10/8/6", 4, "60/70/80/90", 1 },
                    { 3, "Legs", "Squads", "12/10/8", 3, "60/70/80", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutDetails",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
