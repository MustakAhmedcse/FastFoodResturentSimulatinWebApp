using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodResturentWebApp.Models
{
    public class UserInput
    {
        public int Id { get; set; }
        public int CalculateTime { get; set; }
        public int InterArrivalTime { get; set; }
        public int ServiceTime { get; set; }
    }
}