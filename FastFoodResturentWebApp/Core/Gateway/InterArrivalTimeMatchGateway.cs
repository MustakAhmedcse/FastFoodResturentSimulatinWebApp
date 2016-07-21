using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Models;
using Microsoft.Owin;

namespace FastFoodResturentWebApp.Core.Gateway
{
    public class InterArrivalTimeMatchGateway : Gateway
    {
        public int Insert(InterArrivalTimeMatch interArrivalTimeMatch)
        {
            Query = "INSERT INTO InterArrivalTimeMatch_Table (InterArrivalTime,MinRange,MaxRange) VALUES (" + interArrivalTimeMatch.InterArrivalTime + "," + interArrivalTimeMatch.MinRange + "," + interArrivalTimeMatch.MaxRange + ")";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}