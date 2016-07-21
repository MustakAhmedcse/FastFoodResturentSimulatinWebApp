using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodResturentWebApp.Models
{
    public class ServiceTiemMatch
    {
        public int Id { get; set; }
        public decimal ServiceTiem { get; set; }
        public decimal MinRange { get; set; }
        public decimal MaxRange { get; set; }
    }
}