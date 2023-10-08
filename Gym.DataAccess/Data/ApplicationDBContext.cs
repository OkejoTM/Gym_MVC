using Gym.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){ }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutDetails> WorkoutDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { Id = "1", Name = "Tiko", UserName="tiko@mail.ru", Email = "tiko@mail.ru"}
                );

            modelBuilder.Entity<WorkoutPlan>()
                .HasOne(wp => wp.ApplicationUser)
                .WithMany(u => u.WorkoutPlans)
                .HasForeignKey(wp => wp.ApplicationUserId);

            modelBuilder.Entity<WorkoutPlan>().HasData(
                new WorkoutPlan { Id = 1, Date = new DateTime(2023, 8, 1), Notes = "Today im david goggins", ApplicationUserId = "1" },
                new WorkoutPlan { Id = 2, Date = new DateTime(2023, 8, 3), Notes = "Today im still david goggins", ApplicationUserId = "1" },
                new WorkoutPlan { Id = 3, Date = new DateTime(2023, 8, 5), Notes = "Today im the DAVID GOGGINGS" , ApplicationUserId = "1" }
                );
            modelBuilder.Entity<WorkoutDetails>().HasData(
                new WorkoutDetails { Id = 1, Muscle = "Back", Name = "Deadlift", Reps = "12/10/8", Sets = 3, Weight = "60/70/80" , WorkoutPlanId=2},
                new WorkoutDetails { Id = 2, Muscle = "Chest", Name = "Chest Press", Reps = "12/10/8/6", Sets = 4, Weight = "60/70/80/90" , WorkoutPlanId=1},
                new WorkoutDetails { Id = 3, Muscle = "Legs", Name = "Squads", Reps = "12/10/8", Sets = 3, Weight = "60/70/80", WorkoutPlanId = 3}
                );

        }

    }
}
