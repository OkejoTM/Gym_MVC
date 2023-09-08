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

        public IActionResult Upsert(int? id)
        {
            WorkoutPlan workoutPlan;
            if (id == null || id == 0)
            {
                // create
                workoutPlan = new WorkoutPlan();
                return View(workoutPlan);
            }
            else
            {
                // update
                workoutPlan = _unitOfWork.WorkoutPlan.Get(u => u.Id == id);
                return View(workoutPlan);                
            }

        }
        [HttpPost]
        public IActionResult Upsert(WorkoutPlan obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.WorkoutPlan.Add(obj);
                }
                else
                {
                    _unitOfWork.WorkoutPlan.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Workout Plan created successfully";
                return RedirectToAction("Index"); // If need to redirect to another controller write ("Index","Controller")
            }
            return View();
        }

        

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<WorkoutPlan> objWorkoutPlansList = _unitOfWork.WorkoutPlan.GetAll().ToList();
            return Json(new { data = objWorkoutPlansList });
        }   

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.WorkoutPlan.Get(x => x.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deliting" });
            }

            _unitOfWork.WorkoutPlan.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful!" });
        }

        #endregion
    }
}
