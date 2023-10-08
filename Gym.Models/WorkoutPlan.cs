using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models
{
    public class WorkoutPlan
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Chose Date and Time")]
        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Write Some Notes")]
        [MaxLength(120, ErrorMessage = "Maximum length is 120 symbols!")]
        public string Notes { get; set; }

        public virtual ICollection<WorkoutDetails> Details { get; } = new List<WorkoutDetails>();
        
        
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
