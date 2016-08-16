using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastFoodResturentWebApp.Models
{
    public class UserInput
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("How many time you want to simulate")]
        public int CalculateTime { get; set; }
        
    }
}