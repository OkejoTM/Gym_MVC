using GymWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace GymWebRazor_Temp.Data
{
    public class ApplicationRazorDbContext : DbContext  
    {
        public ApplicationRazorDbContext(DbContextOptions<ApplicationRazorDbContext> options) : base(options) { }       

        DbSet<WorkoutPlan> WorkoutPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutPlan>().HasData(
                new WorkoutPlan { Id = 1, Date = new DateTime(2023, 8, 1), Notes = "Triceps" },
                new WorkoutPlan { Id = 2, Date = new DateTime(2023, 8, 3), Notes = "Bicceps" },
                new WorkoutPlan { Id = 3, Date = new DateTime(2023, 8, 5), Notes = "Chest" });
        }
    }
}
