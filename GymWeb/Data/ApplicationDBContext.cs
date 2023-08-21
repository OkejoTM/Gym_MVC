using GymWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GymWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){ }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutPlan>().HasData(
                new WorkoutPlan { Id = 1, Date = new DateTime(2023, 8, 1), Notes = "Today im david goggins"},
                new WorkoutPlan { Id = 2, Date = new DateTime(2023, 8, 3), Notes = "Today im still david goggins" },
                new WorkoutPlan { Id = 3, Date = new DateTime(2023, 8, 5), Notes = "Today im the DAVID GOGGINGS" }
                );
        }

    }
}
