using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodResturentWebApp.Core.Manager;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Controllers
{
    public class ServiceTiemMatchController : Controller
    {
        ServiceTimeMatchManager serviceTimeMatchManager=new ServiceTimeMatchManager();

       [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ServiceTiemMatch serviceTiemMatch )
        {
            ViewBag.message = serviceTimeMatchManager.Insert(serviceTiemMatch);
            return View();
        }

	}
}