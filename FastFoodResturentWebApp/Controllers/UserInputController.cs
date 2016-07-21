using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodResturentWebApp.Core.Manager;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Controllers
{
    public class UserInputController : Controller
    {
       UserInputManager userInputManager=new UserInputManager();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserInput userInput)
        {
            ViewBag.message = userInputManager.Insert(userInput);
            return View();
        }
	}
}