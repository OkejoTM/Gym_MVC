﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class ApplicationUser : IdentityUser
    {       
        [Required]
        public string Name { get; set; }      
        
        public virtual ICollection<WorkoutPlan> WorkoutPlans { get; } = new List<WorkoutPlan>();
         
    }
}
