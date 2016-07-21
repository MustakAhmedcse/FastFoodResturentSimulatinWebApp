using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Core.Gateway
{
    public class ServiceTiemMatchGateway:Gateway
    {
        public int Insert(ServiceTiemMatch serviceTiemMatch)
        {
            Query = "INSERT INTO ServiceTimeMatch_Table VALUES (" + serviceTiemMatch.ServiceTiem + "," + serviceTiemMatch.MinRange + "," + serviceTiemMatch.MaxRange + ")";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}