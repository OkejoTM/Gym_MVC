using GymWeb.Data;
using GymWeb.Models;
using Microsoft.AspNetCore.Mvc;


namespace GymWeb.Controllers
{
    public class WorkoutPlanController : Controller
    {
        private readonly ApplicationDBContext _db;
        public WorkoutPlanController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<WorkoutPlan> objWorkoutPlansList = _db.WorkoutPlans.ToList();
            
            return View(objWorkoutPlansList);
        }
    }
}
