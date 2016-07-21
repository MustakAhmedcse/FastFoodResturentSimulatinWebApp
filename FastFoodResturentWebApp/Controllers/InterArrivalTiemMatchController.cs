using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodResturentWebApp.Core.Manager;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Controllers
{
    public class InterArrivalTiemMatchController : Controller
    {
        InterArrivalTimeMatchManager interArrivalTimeMatchManager=new InterArrivalTimeMatchManager();

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(InterArrivalTimeMatch interArrivalTimeMatch)
        {
            ViewBag.message = interArrivalTimeMatchManager.Insert(interArrivalTimeMatch);
            return View();
        }
	}
}