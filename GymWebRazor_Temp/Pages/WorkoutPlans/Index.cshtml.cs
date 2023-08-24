using GymWebRazor_Temp.Data;
using GymWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWebRazor_Temp.Pages.WorkoutPlans
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationRazorDbContext _db;
        public List<WorkoutPlan> WorkoutPlanList{ get; set; }

        public IndexModel(ApplicationRazorDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            WorkoutPlanList = _db.WorkoutPlans.ToList(); 
        }   
    }
}
