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
        InterArrivalTimeMatchManager interArrivalTimeMatchManager = new InterArrivalTimeMatchManager();

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

        public ActionResult ShowAllInterArrivalData()
        {
            return View(interArrivalTimeMatchManager.GetAllInterArrivalTimes());
        }

        public ActionResult Edit(int id)
        {
            InterArrivalTimeMatch model = interArrivalTimeMatchManager.GetInterArrivalTimeById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InterArrivalTimeMatch model)
        {
            interArrivalTimeMatchManager.UpdateInterArrivalTimeRange(model);
            return RedirectToAction("ShowAllInterArrivalData", "InterArrivalTiemMatch");
        }

        public ActionResult Delete(int id)
        {
            InterArrivalTimeMatch model = interArrivalTimeMatchManager.GetInterArrivalTimeById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(InterArrivalTimeMatch model)
        {
            interArrivalTimeMatchManager.DeleteInterArrivalTimeById(model.Id);
            return RedirectToAction("ShowAllInterArrivalData", "InterArrivalTiemMatch"); 
        }
    }
}