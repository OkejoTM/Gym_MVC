using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GymWebRazor_Temp.Models
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
