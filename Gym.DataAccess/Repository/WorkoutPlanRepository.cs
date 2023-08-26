using Gym.DataAccess.Data;
using Gym.DataAccess.Repository.IRepository;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repository
{
    public class WorkoutPlanRepository : Repository<WorkoutPlan>, IWorkoutPlanRepository
    {

        private readonly ApplicationDBContext _db;

        public WorkoutPlanRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(WorkoutPlan obj)
        {
            _db.WorkoutPlans.Update(obj);
        }
    }
}
