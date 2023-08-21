using System.ComponentModel.DataAnnotations;

namespace GymWeb.Models
{
    public class WorkoutPlan
    {
        [Key]      
        public  int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [StringLength(maximumLength:120)]
        public string Notes { get; set; }

    }
}
