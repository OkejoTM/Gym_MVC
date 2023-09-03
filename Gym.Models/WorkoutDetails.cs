using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [DisplayName("Muscle")]
        public string Muscle { get; set; }
        [Required]
        [DisplayName("Sets")]
        public int Sets { get; set; }
        [Required]
        [DisplayName("Reps")]
        public string Reps { get; set; }
        [Required]
        [DisplayName("Weight")]
        public string Weight { get; set; }

        public int WorkoutPlanId { get; set; }

        [ValidateNever]
        [ForeignKey("WorkoutPlanId")]        
        public WorkoutPlan WorkoutPlan { get; set; } = null!;

    }
}
