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
        public List<ServiceTiemMatch> GetAllServiceTimes()
        {
            List<ServiceTiemMatch> interArrivalTimeMatches = new List<ServiceTiemMatch>();
            Query = "SELECT * FROM ServiceTimeMatch_Table";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ServiceTiemMatch serviceTiemMatch = new ServiceTiemMatch();
                serviceTiemMatch.ServiceTiem = Convert.ToInt32(Reader["ServiceTime"]);
                serviceTiemMatch.MinRange = Convert.ToInt32(Reader["MinRange"]);
                serviceTiemMatch.MaxRange = Convert.ToInt32(Reader["MaxRange"]);
                interArrivalTimeMatches.Add(serviceTiemMatch);
            }
            Reader.Close();
            Connection.Close();
            return interArrivalTimeMatches;
        }
    }
}