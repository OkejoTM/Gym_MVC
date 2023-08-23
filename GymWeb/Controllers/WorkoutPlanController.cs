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

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(WorkoutPlan obj)
        {
            if (ModelState.IsValid)
            {
                _db.WorkoutPlans.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); // If need to redirect to another controller write ("Index","Controller")
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            WorkoutPlan? workoutPlan = _db.WorkoutPlans.FirstOrDefault(u=>u.Id == id);
            if (workoutPlan == null)
            {
                return NotFound();
            }

            return View(workoutPlan);
        }
        [HttpPost]
        public IActionResult Edit(WorkoutPlan obj)
        {
            if (ModelState.IsValid)
            {
                _db.WorkoutPlans.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            WorkoutPlan? workoutPlan = _db.WorkoutPlans.FirstOrDefault(u => u.Id == id);
            if (workoutPlan == null)
            {
                return NotFound();
            }

            return View(workoutPlan);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            WorkoutPlan? obj = _db.WorkoutPlans.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.WorkoutPlans.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
