using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gym.Models
{
    public class WorkoutDetails
    {
        [Key]        
        public int Id { get; set; }
        [Required]
        [DisplayName("Name Of Excercise")]                
        public string Name { get; set; }
        [Required]
        public string Muscle { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required]  
        public string Reps { get; set; }
        [Required]
        public string Weight { get; set; }

        [ForeignKey("WorkoutPlanId")]
        public int WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; } = null!;

    }
}
