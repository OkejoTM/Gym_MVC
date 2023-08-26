using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repository.IRepository
{
    public interface IWorkoutPlanRepository : IRepository<WorkoutPlan>
    {
        void Update(WorkoutPlan obj);
        void Save();
    }
}
