using Gym.DataAccess.Data;
using Gym.Models;
using Gym.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;



namespace GymWeb.Controllers
{
    public class WorkoutPlanController : Controller
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;

        public WorkoutPlanController(IWorkoutPlanRepository workoutPlanRepository)
        {
            _workoutPlanRepository = workoutPlanRepository;
        }

        public IActionResult Index()
        {
            List<WorkoutPlan> objWorkoutPlansList = _workoutPlanRepository.GetAll().ToList();
            
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
                _workoutPlanRepository.Add(obj);
                _workoutPlanRepository.Save();
                TempData["success"] = "Workout Plan created successfully";
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

            WorkoutPlan? workoutPlan = _workoutPlanRepository.Get(u=>u.Id == id);
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
                _workoutPlanRepository.Update(obj);
                _workoutPlanRepository.Save();
                TempData["success"] = "Workout Plan updated successfully";
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

            WorkoutPlan? workoutPlan = _workoutPlanRepository.Get(u => u.Id == id);
            if (workoutPlan == null)
            {
                return NotFound();
            }

            return View(workoutPlan);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            WorkoutPlan? obj = _workoutPlanRepository.Get(u=>u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _workoutPlanRepository.Remove(obj);
            _workoutPlanRepository.Save();
            TempData["success"] = "Workout Plan deleted successfully";
            return RedirectToAction("Index");
        }



    }
}
