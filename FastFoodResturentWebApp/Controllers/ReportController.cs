//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace FastFoodResturentWebApp.Controllers
//{
//    public class ReportController : Controller
//    {
//        // GET api/<controller> 
//        [HttpGet]
//        public async Task<HttpResponseMessage> GetPDFReport()
//        {
//            string fileName = string.Concat("Contacts.pdf");
//            string filePath = HttpContext.Current.Server.MapPath("~/Report/" + fileName);

//            ContactController contact = new ContactController();
//            List<Contact> contacList = contact.Get().ToList();

//            await SampleEF6.Report.ReportGenerator.GeneratePDF(contacList, filePath);

//            HttpResponseMessage result = null;
//            result = Request.CreateResponse(HttpStatusCode.OK);
//            result.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
//            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
//            result.Content.Headers.ContentDisposition.FileName = fileName;

//            return result;
//        } 
//    }
//}
using System; 
using System.Collections.Generic; 
using System.Data.Entity; 
using System.Data.Entity.Infrastructure; 
using System.Linq; 
using System.Net; 
using System.Net.Http; 
using System.Web.Http;
using System.Web.Mvc;
using FastFoodResturentWebApp.Models; 
using System.Threading.Tasks; 
using System.Web; 
using System.IO; 
using System.Net.Http.Headers; 
 
namespace FastFoodResturentWebApp.Controllers 
{
    public class ReportController : Controller 
    { 
        // GET api/<controller> 
        [HttpGet] 
        public async Task<HttpResponseMessage> GetPDFReport() 
        { 
            string fileName = string.Concat("Contacts.pdf"); 
            string filePath = HttpContext.Current.Server.MapPath("~/Report/Report1.rdlc");

            ReportController contact = new ReportController(); 
            List<Report1> contacList = Retport1.Get().ToList();

            await FastFoodResturentWebApp.Report.ReportGenerator.GeneratePDF(contacList, filePath); 
 
            HttpResponseMessage result = null; 
            result = Request.CreateResponse(HttpStatusCode.OK); 
            result.Content = new StreamContent(new FileStream(filePath, FileMode.Open)); 
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); 
            result.Content.Headers.ContentDisposition.FileName = fileName; 
 
            return result; 
        } 
    } 
}