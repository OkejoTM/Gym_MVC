using GymWebRazor_Temp.Data;
using GymWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWebRazor_Temp.Pages.WorkoutPlans
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationRazorDbContext _db;
        [BindProperty]
        public WorkoutPlan WorkoutPlan { get; set; }
        public CreateModel(ApplicationRazorDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        
        public IActionResult OnPost()
        {
            _db.WorkoutPlans.Add(WorkoutPlan);
            _db.SaveChanges();
            return RedirectToPage("Index");  
        }
    }
}
