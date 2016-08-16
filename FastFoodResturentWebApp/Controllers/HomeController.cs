using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using FastFoodResturentWebApp.Core.Manager;

namespace FastFoodResturentWebApp.Controllers
{

    public class HomeController : Controller
    {
        UserInputManager userInputManager=new UserInputManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ReportsEverest()
        {
            List<FinalResult_Table> allFinalData = new List<FinalResult_Table>();
            using (FastFoodResturent_DBEntities2 dc = new FastFoodResturent_DBEntities2())
            {
                allFinalData = dc.FinalResult_Table.ToList();
            }
            return View(allFinalData);
        }
        public ActionResult ExportReport()
        {

            List<FinalResult_Table> allFinalData = new List<FinalResult_Table>();
            //using (FastFoodResturent_DBEntities dc = new FastFoodResturent_DBEntities())
            //{
            //    allFinalData = dc.FinalResult_Table.ToList();
            //}
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "MyReport.rpt"));
            rd.SetDataSource(userInputManager.GetAllFinalInfo());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "SimulationResultPage.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}