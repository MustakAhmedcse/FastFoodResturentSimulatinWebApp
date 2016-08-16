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
            List<ServiceTiemMatch> serviceTiemMatchsList = new List<ServiceTiemMatch>();
            Query = "SELECT * FROM ServiceTimeMatch_Table";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ServiceTiemMatch serviceTiemMatch = new ServiceTiemMatch();

                serviceTiemMatch.Id = Convert.ToInt32(Reader["Id"]);
                serviceTiemMatch.ServiceTiem = Convert.ToInt32(Reader["ServiceTime"]);
                serviceTiemMatch.MinRange = Convert.ToInt32(Reader["MinRange"]);
                serviceTiemMatch.MaxRange = Convert.ToInt32(Reader["MaxRange"]);
                serviceTiemMatchsList.Add(serviceTiemMatch);
            }
            Reader.Close();
            Connection.Close();
            return serviceTiemMatchsList;
        }


        public ServiceTiemMatch GetServiceTimeById(int id)
        {
            ServiceTiemMatch serviceTiemMatch = new ServiceTiemMatch();
            Query = "SELECT * FROM ServiceTimeMatch_Table Where Id=" + id + " ";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {

                serviceTiemMatch.Id = Convert.ToInt32(Reader["Id"]);
                serviceTiemMatch.ServiceTiem = Convert.ToInt32(Reader["ServiceTime"]);
                serviceTiemMatch.MinRange = Convert.ToInt32(Reader["MinRange"]);
                serviceTiemMatch.MaxRange = Convert.ToInt32(Reader["MaxRange"]);

                Reader.Close();
                Connection.Close();
            }
            return serviceTiemMatch;
        }

        public void UpdateServiceTimeRange(ServiceTiemMatch model)
        {
            Query = "UPDATE ServiceTimeMatch_Table SET ServiceTime=" + model.ServiceTiem +
                     ",MaxRange=" + model.MaxRange + ",MinRange=" + model.MinRange +
                     " WHERE Id=" + model.Id + " ";
            Command.CommandText = Query;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
           
        }

        public void DeleteServiceTimeById(int id)
        {
            Query = "Delete from ServiceTimeMatch_Table Where Id=" + id + " ";
            Command.CommandText = Query;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}