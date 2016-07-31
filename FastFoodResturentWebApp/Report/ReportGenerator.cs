using Microsoft.Reporting.WebForms;
using SampleEF6.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web; 
 
namespace FastFoodResturentWebApp.Report
{
    public class ReportGenerator
    {
        public static string Report1 = "FastFoodResturentWebApp.Report.Report1.rdlc";

        public static Task GeneratePDF(List<Report1> datasource, string filePath)
        {
            return Task.Run(() =>
            {
                string binPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
                var assembly = Assembly.Load(System.IO.File.ReadAllBytes(binPath + "\\FastFoodResturentWebApp.dll"));

                using (Stream stream = assembly.GetManifestResourceStream(Report1))
                {
                    var viewer = new ReportViewer();
                    viewer.LocalReport.EnableExternalImages = true;
                    viewer.LocalReport.LoadReportDefinition(stream);

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string filenameExtension;

                    viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetContacts", datasource));

                    viewer.LocalReport.Refresh();

                    byte[] bytes = viewer.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding, out filenameExtension,
                        out streamids, out warnings);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            });
        }
    }
}