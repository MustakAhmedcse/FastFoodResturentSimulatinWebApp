using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Core.Gateway
{
    public class UserInputGateway:Gateway
    {
        public int Insert(UserInput userInput)
        {
            //  Query = "UPDATE UserInput_Table SET(" + userInput.CalculateTime + "," + userInput.InterArrivalTime + "," + userInput.ServiceTime + ") WHERE "userInput.Id"";

            Query = "UPDATE UserInput_Table SET CalculateTime=" + userInput.CalculateTime + ",InterArrivalTime=" + userInput.InterArrivalTime + ",ServiceTime=" + userInput.ServiceTime + " WHERE Id=1";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}