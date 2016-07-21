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
            int calculateTime= userInput.CalculateTime;
            Random r = new Random();
            int [] interArrivalTimeRandomDegits=new int[calculateTime-1];
            for (int i = 0; i < calculateTime-1; i++)
            {
                interArrivalTimeRandomDegits[i] = r.Next(100);
            }

            int[] servicelTimeRandomDegits = new int[calculateTime];
            for (int i = 0; i < calculateTime; i++)
            {
                servicelTimeRandomDegits[i] = r.Next(1000);
            }

            //int x = r.Next(100); //Max range
            ViewBag.message = userInputManager.Insert(userInput);
            return View();
        }




	}
}