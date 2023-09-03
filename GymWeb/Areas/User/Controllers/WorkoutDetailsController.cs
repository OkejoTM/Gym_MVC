using Gym.DataAccess.Data;
using Gym.DataAccess.Repository.IRepository;
using Gym.Models;
using Gym.Models.ViewModels;
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

        public IActionResult Index(int? id)
        {
            if (id != null && id != 0)
            {
                WorkoutDetailsVM workoutDetailsVM = new()
                {
                    WorkoutDetailsList = _unitOfWork.WorkoutDetails.GetAll().Where(u => u.WorkoutPlanId == id).ToList(),
                    WorkoutPlanId = (int)id
                };                
                return View(workoutDetailsVM);
            }
            return NotFound();
        }


        public IActionResult Create(int? id)
        {
            if (id != null && id != 0)
            {
                var viewModel = new WorkoutDetails
                {
                    WorkoutPlanId = (int)id
                };                
                return View(viewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(WorkoutDetails obj)
        {
            obj.Id = 0;            
            if (ModelState.IsValid)
            {
                _unitOfWork.WorkoutDetails.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Deatils created successfuly";
                return RedirectToAction("Index", new { id = obj.WorkoutPlanId});
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
                return RedirectToAction("Index", new { id = workoutDetails.WorkoutPlanId});
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
            obj.WorkoutPlan = _unitOfWork.WorkoutPlan.Get(u=>u.Id == obj.WorkoutPlanId);
            if (obj.WorkoutPlan == null)
            {
                ModelState.AddModelError("WorkoutPlan", "WorkoutPlan is null");
            }            
            if (ModelState.IsValid)
            {
                _unitOfWork.WorkoutDetails.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Deatils updated successfuly";
                return RedirectToAction("Index", new { id = obj.WorkoutPlanId });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);            
            return View();
        }

        



    }
}
