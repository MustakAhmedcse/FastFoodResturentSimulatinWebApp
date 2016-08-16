using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastFoodResturentWebApp.Models
{
    public class ServiceTiemMatch
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter a Service Time.")]
        [DisplayName("Service Time")]
        public decimal ServiceTiem { get; set; }

        [Required(ErrorMessage = "Please Enter Mnimul Range.")]
        [DisplayName("Minimun Range")]
        public decimal MinRange { get; set; }

        [Required(ErrorMessage = "Please Enter Maximum Range.")]
        [DisplayName("Maximum Range")]
        public decimal MaxRange { get; set; }
    }
}