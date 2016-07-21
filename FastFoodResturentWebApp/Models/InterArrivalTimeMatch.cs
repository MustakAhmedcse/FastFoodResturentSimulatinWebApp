using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodResturentWebApp.Models
{
    public class InterArrivalTimeMatch
    {
        public int Id { get; set; }
        public decimal InterArrivalTime { get; set; }
        public decimal MinRange { get; set; }
        public decimal MaxRange { get; set; }
       
    }
}