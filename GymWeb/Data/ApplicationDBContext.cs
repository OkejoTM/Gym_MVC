using GymWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GymWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){ }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }

    }
}
