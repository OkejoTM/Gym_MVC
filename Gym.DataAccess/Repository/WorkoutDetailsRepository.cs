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
    public class WorkoutDetailsRepository : Repository<WorkoutDetails>, IWorkoutDetailsRepository
    {

        private readonly ApplicationDBContext _db;

        public WorkoutDetailsRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
                
        public void Update(WorkoutDetails obj)
        {
            _db.WorkoutDetails.Update(obj);
        }
    }
}
