using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedWorkoutPlansTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Date", "Notes" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Today im david goggins" },
                    { 2, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Today im still david goggins" },
                    { 3, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Today im the DAVID GOGGINGS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
