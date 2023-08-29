using Gym.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){ }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutDetails> WorkoutDetails { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutPlan>().HasData(
                new WorkoutPlan { Id = 1, Date = new DateTime(2023, 8, 1), Notes = "Today im david goggins"},
                new WorkoutPlan { Id = 2, Date = new DateTime(2023, 8, 3), Notes = "Today im still david goggins" },
                new WorkoutPlan { Id = 3, Date = new DateTime(2023, 8, 5), Notes = "Today im the DAVID GOGGINGS" }
                );

            modelBuilder.Entity<WorkoutDetails>().HasData(
                new WorkoutDetails { Id = 1, Muscle = "Back", Name = "Deadlift", Reps = "12/10/8", Sets = 3, Weight = "60/70/80" , WorkoutPlanId=2},
                new WorkoutDetails { Id = 2, Muscle = "Chest", Name = "Chest Press", Reps = "12/10/8/6", Sets = 4, Weight = "60/70/80/90" , WorkoutPlanId=1},
                new WorkoutDetails { Id = 3, Muscle = "Legs", Name = "Squads", Reps = "12/10/8", Sets = 3, Weight = "60/70/80", WorkoutPlanId = 3}
                );

        }

    }
}
