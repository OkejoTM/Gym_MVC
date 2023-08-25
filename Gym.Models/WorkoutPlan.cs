using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

    }
}
