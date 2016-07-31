<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewerASPX.aspx.cs" Inherits="FastFoodResturentWebApp.Views.Shared.ReportViewerASPX" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportrViewing in MVC Application</title>
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MVCReportViwer.Customer> customers = null;
                using (MVCReportViwer.MyDatabaseEntities dc = new MVCReportViwer.MyDatabaseEntities())
                {
                    customers = dc.Customers.OrderBy(a => a.CustomerID).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("MyDataset", customers);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="482px" Width="687px">
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
