using Gym.DataAccess.Data;
using Gym.DataAccess.Repository.IRepository;
using Gym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GymWeb.Areas.User.Controllers
{
    [Area("User")]
    public class WorkoutDetailsController : Controller
    {        
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutDetailsController( IUnitOfWork unitOfWork)
        {            
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? workoutPlanId)
        {
            if (workoutPlanId != null && workoutPlanId != 0)
            {
                List<WorkoutDetails> workoutDetails = _unitOfWork.WorkoutDetails.GetAll().ToList();
                return View(workoutDetails);
            }
            return NotFound();
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(WorkoutDetails obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WorkoutDetails.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Deatils created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            WorkoutDetails? workoutDetails = _unitOfWork.WorkoutDetails.Get(x=>x.Id == id);
            if (workoutDetails == null)
            {
                return NotFound();
            }
            return View(workoutDetails);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {            
            WorkoutDetails? workoutDetails = _unitOfWork.WorkoutDetails.Get(x => x.Id == id);
            if (workoutDetails != null)
            {
                _unitOfWork.WorkoutDetails.Remove(workoutDetails);
                _unitOfWork.Save();
                TempData["success"] = "Details deleted successfuly";
                return RedirectToAction("Index");
            }
            return NotFound();

        }

        public IActionResult Edit(int? id)
        {
            WorkoutDetails workoutDetails = _unitOfWork.WorkoutDetails.Get(x=>x.Id == id);
            if (workoutDetails != null)
            {
                return View(workoutDetails);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(WorkoutDetails obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WorkoutDetails.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Deatils updated successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }




    }
}
