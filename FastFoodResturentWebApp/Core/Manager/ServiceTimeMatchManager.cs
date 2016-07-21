﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Core.Gateway;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Core.Manager
{
    public class ServiceTimeMatchManager
    {
        ServiceTiemMatchGateway serviceTiemMatchGateway=new ServiceTiemMatchGateway();

        public string Insert(ServiceTiemMatch serviceTiemMatch)
        {
            if (serviceTiemMatchGateway.Insert(serviceTiemMatch) > 0)
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