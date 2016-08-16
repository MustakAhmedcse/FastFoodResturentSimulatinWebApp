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
            Query = "INSERT INTO InterArrivalTimeMatch_Table (InterArrivalTime,MinRange,MaxRange) VALUES (" +
                    interArrivalTimeMatch.InterArrivalTime + "," + interArrivalTimeMatch.MinRange + "," +
                    interArrivalTimeMatch.MaxRange + ")";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<InterArrivalTimeMatch> GetAllInterArrivalTimes()
        {
            List<InterArrivalTimeMatch> interArrivalTimeMatches = new List<InterArrivalTimeMatch>();
            Query = "SELECT * FROM InterArrivalTimeMatch_Table";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                InterArrivalTimeMatch interArrivalTimeMatch = new InterArrivalTimeMatch();
                interArrivalTimeMatch.Id = Convert.ToInt32(Reader["Id"]);
                interArrivalTimeMatch.InterArrivalTime = Convert.ToInt32(Reader["InterArrivalTime"]);
                interArrivalTimeMatch.MinRange = Convert.ToInt32(Reader["MinRange"]);
                interArrivalTimeMatch.MaxRange = Convert.ToInt32(Reader["MaxRange"]);
                interArrivalTimeMatches.Add(interArrivalTimeMatch);
            }
            Reader.Close();
            Connection.Close();
            return interArrivalTimeMatches;
        }

        public int UpdateInterArrivalTimeRange(InterArrivalTimeMatch interArrivalTimeMatch)
        {
            Query = "UPDATE InterArrivalTimeMatch_Table SET InterArrivalTime=" + interArrivalTimeMatch.InterArrivalTime +
                    ",MaxRange=" + interArrivalTimeMatch.MaxRange + ",MinRange=" + interArrivalTimeMatch.MinRange +
                    " WHERE Id=" + interArrivalTimeMatch.Id + " ";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

       
        public InterArrivalTimeMatch GetInterArrivalTimeById(int id)
        {
            InterArrivalTimeMatch interArrivalTimeMatch = new InterArrivalTimeMatch();
            Query = "SELECT * FROM InterArrivalTimeMatch_Table Where Id=" + id + " ";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {

                interArrivalTimeMatch.Id = Convert.ToInt32(Reader["Id"]);
                interArrivalTimeMatch.InterArrivalTime = Convert.ToInt32(Reader["InterArrivalTime"]);
                interArrivalTimeMatch.MinRange = Convert.ToInt32(Reader["MinRange"]);
                interArrivalTimeMatch.MaxRange = Convert.ToInt32(Reader["MaxRange"]);

                Reader.Close();
                Connection.Close();
            }
            return interArrivalTimeMatch;
        }

        public void DeleteInterArrivalTimeById(int id)
        {
            Query = "Delete from InterArrivalTimeMatch_Table Where Id="+id+" ";
            Command.CommandText = Query;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
         
        }
    }
}