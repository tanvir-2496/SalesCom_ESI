using ClosedXML.Excel;
using SalesCom.DAL;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

public partial class DownloadWithheldDetails : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request["type"] != null)
        {
            string commissionName = string.Empty;

            DataTable dt = new DataTable(); ;

            if (Request["type"] == "1" && string.IsNullOrEmpty(Request["fileName"]).Equals(false) && string.IsNullOrEmpty(Request["reportCycle"]).Equals(false)
                && string.IsNullOrEmpty(Request["id"]).Equals(false) && string.IsNullOrEmpty(Request["recipientCode"]).Equals(false))
            {
                commissionName = String.Format("Withheld Details of {0}_{1}", Request["fileName"], Request["reportCycle"]);
                dt = HeadWiseWithheldListDAL.Get_Withheld_Com_Channel_Wise(Convert.ToInt32(Request["id"]), Request["recipientCode"]);
            }
            else if (Request["type"] == "2" && string.IsNullOrEmpty(Request["recipientCode"]).Equals(false))
            {
                commissionName = String.Format("Withheld Commission Summary Report for {0}", Request["recipientCode"]);
                dt = HeadWiseWithheldListDAL.Get_Withheld_Com_Summary(Request["recipientCode"]);
            }
            else if (Request["type"] == "3" && string.IsNullOrEmpty(Request["recipientCode"]).Equals(false))
            {
                commissionName = String.Format("Withheld Commission Details Report for {0}", Request["recipientCode"]);
                dt = HeadWiseWithheldListDAL.Get_Withheld_Com_Recipient_all(Request["recipientCode"]);
            }
            else if (Request["type"] == "4" && string.IsNullOrEmpty(Request["reportCycle"]).Equals(false) && string.IsNullOrEmpty(Request["reportName"]).Equals(false)
                && string.IsNullOrEmpty(Request["commissiomCycle"]).Equals(false))
            {
                commissionName = String.Format("Withheld Details of {0}_{1}", Request["reportName"], Request["commissiomCycle"]);
                dt = ReportWiseWithheldListDAL.Get_Report_Wise_Withheld_dtls(Convert.ToInt32(Request["reportCycle"]));
            }

            if (dt.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(dt, "Commission Details");
                    ws.Tables.FirstOrDefault().ShowAutoFilter = false;
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}.xlsx", commissionName));
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.SuppressContent = true;
                    }
                }
            }
        }
    }
}