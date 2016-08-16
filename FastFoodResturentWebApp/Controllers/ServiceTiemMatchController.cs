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

        public ActionResult ShowAllServiceTimeData()
        {
            return View(serviceTimeMatchManager.GetAllServiceTimes());
        }

        public ActionResult Edit(int id)
        {
            ServiceTiemMatch model = serviceTimeMatchManager.GetServiceTimeById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ServiceTiemMatch model)
        {
            serviceTimeMatchManager.UpdateServiceTimeRange(model);
            return RedirectToAction("ShowAllServiceTimeData", "ServiceTiemMatch");
        }

        public ActionResult Delete(int id)
        {
            ServiceTiemMatch model = serviceTimeMatchManager.GetServiceTimeById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(InterArrivalTimeMatch model)
        {
            serviceTimeMatchManager.DeleteServiceTimeById(model.Id);
            return RedirectToAction("ShowAllServiceTimeData", "ServiceTiemMatch");
        }
    }
}