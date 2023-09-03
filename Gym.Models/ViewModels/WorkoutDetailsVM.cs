using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.ViewModels
{
    public class WorkoutDetailsVM
    {
        public IEnumerable<WorkoutDetails> WorkoutDetailsList { get; set; }
        public int WorkoutPlanId { get; set; }
    }
}
