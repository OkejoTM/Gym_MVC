using GymWebRazor_Temp.Data;
using GymWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWebRazor_Temp.Pages.WorkoutPlans
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationRazorDbContext _db;
        [BindProperty]
        public WorkoutPlan WorkoutPlan { get; set; }

        public DeleteModel(ApplicationRazorDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id )
        {
            if (id != null || id != 0)
            {
                WorkoutPlan = _db.WorkoutPlans.Find(id);
            }            
        }

        public IActionResult OnPost()
        {
            if (WorkoutPlan != null) 
            {            
                _db.WorkoutPlans.Remove(WorkoutPlan);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return NotFound();
        }
    }
}
