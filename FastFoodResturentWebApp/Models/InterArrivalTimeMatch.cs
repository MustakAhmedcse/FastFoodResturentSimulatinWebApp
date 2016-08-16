using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FastFoodResturentWebApp.Models
{
    public class InterArrivalTimeMatch
    {
        public int Id { get; set; }

         [Required(ErrorMessage = "Please Enter an Inter Arrival Time.")]
        [DisplayName("Inter Arrival Time")]
        public decimal InterArrivalTime { get; set; }

         [Required(ErrorMessage = "Please Enter Mnimul Range.")]
         [DisplayName("Minimun Range")]
        public decimal MinRange { get; set; }

         [Required(ErrorMessage = "Please Enter Maximum Range.")]
         [DisplayName("Maximum Range")]
        public decimal MaxRange { get; set; }
       
    }
}