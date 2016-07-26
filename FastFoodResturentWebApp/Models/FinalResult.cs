using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodResturentWebApp.Models
{
    public class FinalResult
    {
        public int Id { get; set; }
        public int InterArrivalTime { get; set; }
        public int ArrivalTime { get; set; }
        public int ServiceTime { get; set; }
        public int ServiceStartTime { get; set; }   
        public int ServiceEndTime { get; set; }   
    }
}