using Gym.DataAccess.Data;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess.Repository.IRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public IWorkoutPlanRepository WorkoutPlan { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            WorkoutPlan = new WorkoutPlanRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges(); ;
        }
    }
}
