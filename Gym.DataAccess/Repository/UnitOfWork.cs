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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public IWorkoutPlanRepository WorkoutPlan { get; private set; }
        public IWorkoutDetailsRepository WorkoutDetails { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            WorkoutPlan = new WorkoutPlanRepository(_db);
            WorkoutDetails = new WorkoutDetailsRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges(); ;
        }
    }
}
