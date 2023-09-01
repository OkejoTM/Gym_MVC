using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repository.IRepository
{
    public interface IWorkoutDetailsRepository : IRepository<WorkoutDetails>
    {
        void Update(WorkoutDetails obj);
    }
}
