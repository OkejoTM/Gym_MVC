using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IWorkoutPlanRepository WorkoutPlan{ get; }
        void Save();
        
    }
}
