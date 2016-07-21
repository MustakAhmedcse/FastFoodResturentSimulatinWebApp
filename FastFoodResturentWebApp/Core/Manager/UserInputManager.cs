using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Core.Gateway;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Core.Manager
{
    public class UserInputManager
    {
        UserInputGateway userInputGateway=new UserInputGateway();

        public string Insert(UserInput userInput)
        {
            if (userInputGateway.Insert(userInput) > 0)
            {
                return "Save Successfull.";
            }
            else
            {
                return "Sory! Save Fail.";
            }
        }
       
    }
}