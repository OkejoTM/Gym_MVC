using GymWebRazor_Temp.Data;
using GymWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWebRazor_Temp.Pages.WorkoutPlans
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationRazorDbContext _db;
        
        public WorkoutPlan WorkoutPlan { get; set; }
        public EditModel(ApplicationRazorDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                WorkoutPlan = _db.WorkoutPlans.Find(id);
            }
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.WorkoutPlans.Update(WorkoutPlan);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
