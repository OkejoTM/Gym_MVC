using Gym.DataAccess.Data;
using Gym.Models;
using Gym.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GymWeb.Areas.User.Controllers
{
    [Area("User")]
    public class WorkoutPlanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutPlanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<WorkoutPlan> objWorkoutPlansList = _unitOfWork.WorkoutPlan.GetAll().ToList();

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
                _unitOfWork.WorkoutPlan.Add(obj);
                _unitOfWork.Save();
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

            WorkoutPlan? workoutPlan = _unitOfWork.WorkoutPlan.Get(u => u.Id == id);
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
                _unitOfWork.WorkoutPlan.Update(obj);
                _unitOfWork.Save();
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

            WorkoutPlan? workoutPlan = _unitOfWork.WorkoutPlan.Get(u => u.Id == id);
            if (workoutPlan == null)
            {
                return NotFound();
            }

            return View(workoutPlan);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            WorkoutPlan? obj = _unitOfWork.WorkoutPlan.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.WorkoutPlan.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Workout Plan deleted successfully";
            return RedirectToAction("Index");
        }



    }
}
