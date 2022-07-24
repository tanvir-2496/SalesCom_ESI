using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.OracleClient;
using ESI.Entity;
using ESI.DAL;
using ESI.Entity.ViewModel;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesCom.DAL;

public partial class OwnDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESIOwnDashboard)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            ddlYear.DataSource = Common.GenrateYear();
            ddlYear.DataBind();
            int year = DateTime.Now.Year;
            int quarter = 0;
            int month = 0;

            var y = ddlYear.Items.FindByText(year.ToString());
            if (y != null)
                y.Selected = true;
            quarter = DateTime.Now.Month % 3 == 0 ? DateTime.Now.Month / 3 : DateTime.Now.Month / 3 + 1;
            var q = ddlQuarter.Items.FindByValue(quarter.ToString());
            if (q != null)
                q.Selected = true;

            KPIvsAchievement(year, quarter, month);
        }
        
    }

    public void KPIvsAchievement(int year, int quarter, int month)
    {
        int userId = LoginInfo.Current.UserId;
        int employeeId=UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO.Length> 0 ?Convert.ToInt32( UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO) : 0;

        ReportCycleEnt reportCycle = ESI_ReportDAL.GetReportCycle(employeeId, year, quarter, month);
        if (reportCycle.REPORT_CYCLE_ID <= 0)
        {
            reportCycle.REPORT_CYCLE_ID = 0;
        }
        List<KPIvsAchievementEnt> report = ESI_ReportDAL.KPIvsAchievement(employeeId, reportCycle.REPORT_CYCLE_ID);
        lv.DataSource = report;
        lv.DataBind();

        #region Arrear table
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleList(employeeId, year, quarter, month);
        Arrear1lv.Visible = false;
        Arrear2lv.Visible = false;
        Arrear3lv.Visible = false;
        Arrear1lvl.Visible = false;
        Arrear2lvl.Visible = false;
        Arrear3lvl.Visible = false;
        btnDownloadReportArrear1.Visible = false;
        btnDownloadReportArrear2.Visible = false;
        btnDownloadReportArrear3.Visible = false;
        btnDownloadScoreCardArrear1.Visible = false;
        btnDownloadScoreCardArrear2.Visible = false;
        btnDownloadScoreCardArrear3.Visible = false;
        if (reportCycleList.Count() >= 2)
        {
            if (reportCycleList[1].REPORT_CYCLE_ID <= 0)
            {
                reportCycleList[1].REPORT_CYCLE_ID = 0;
            }
            List<KPIvsAchievementEnt> arrearreport1 = ESI_ReportDAL.KPIvsAchievement(employeeId, reportCycleList[1].REPORT_CYCLE_ID);
            Arrear1lv.DataSource = arrearreport1;
            Arrear1lv.DataBind();
            Arrear1lv.Visible = true;
            btnDownloadReportArrear1.Visible = true;
            btnDownloadScoreCardArrear1.Visible = true;
            if (arrearreport1.Count() > 0)
            {
                Arrear1lvl.Visible = true;

            }
        }

        if (reportCycleList.Count() >= 3)
        {
            if (reportCycleList[2].REPORT_CYCLE_ID <= 0)
            {
                reportCycleList[2].REPORT_CYCLE_ID = 0;
            }
            List<KPIvsAchievementEnt> arrearreport2 = ESI_ReportDAL.KPIvsAchievement(employeeId, reportCycleList[2].REPORT_CYCLE_ID);
            Arrear2lv.DataSource = arrearreport2;
            Arrear2lv.DataBind();
            Arrear2lv.Visible = true;
            btnDownloadReportArrear2.Visible = true;
            btnDownloadScoreCardArrear2.Visible = true;
            if (arrearreport2.Count() > 0)
            {
                Arrear2lvl.Visible = true;

            }
        }

        if (reportCycleList.Count() >= 4)
        {
            if (reportCycleList[3].REPORT_CYCLE_ID <= 0)
            {
                reportCycleList[3].REPORT_CYCLE_ID = 0;
            }
            List<KPIvsAchievementEnt> arrearreport3 = ESI_ReportDAL.KPIvsAchievement(employeeId, reportCycleList[3].REPORT_CYCLE_ID);
            Arrear3lv.DataSource = arrearreport3;
            Arrear3lv.DataBind();
            Arrear3lv.Visible = true;
            btnDownloadReportArrear3.Visible = true;
            btnDownloadScoreCardArrear3.Visible = true;
            if (arrearreport3.Count() > 0)
            {
                Arrear3lvl.Visible = true;

            }
        }
        #endregion

        #region Chart Start
        if (report.Count<=0)
        {
            KPIChart.Visible = false;
            KPIChart.Controls.Clear();

            DownloadReport.Style["visibility"] = "hidden";
            DownloadScoreCard.Style["visibility"] = "hidden";
        }
        else
        {
            KPIChart.Visible = true;
            KPIChart.Titles.Clear();

            DownloadReport.Style["visibility"] = "";
            DownloadScoreCard.Style["visibility"] = "";
        }
        List<KPIvsAchievementEnt> reportChart = ESI_ReportDAL.KPIvsAchievementChart(employeeId, reportCycle.REPORT_CYCLE_ID);
        KPIChart.ChartAreas["KPIName"].AxisX.Interval = 1;
        KPIChart.DataSource = reportChart;
        KPIChart.Series[0].XValueMember = "KPIName";//KPIChart.DataSource=reportChart
        KPIChart.Series[0].YValueMembers = "TotalQuarterAchievement";
        KPIChart.DataBind();
        //KPIChart.ChartAreas[0].AxisX2.;
        KPIChart.Series[0].Label = "#VALY";
        KPIChart.ChartAreas[0].AxisY.LabelStyle.Format = "{#}%";

        try 
        {
            foreach (var chartitem in KPIChart.Series[0].Points)
            {
                //if (Convert.ToInt32(chartitem.YValues[0]) < 100) 
                //{
                //    chartitem.Color = Color.Red;
                //}
                chartitem.Color = Color.Green;

                foreach (var item in report)
                {
                    if (item.KPIName == chartitem.AxisLabel && item.COLOR_CHANGE == "Y")
                    {
                        chartitem.Color = Color.Red;
                    }
                }
            }
        }
        catch (Exception ex)
        {
                           
        } 
        #endregion
    }
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        int year = Convert.ToInt32( ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);
        KPIvsAchievement(year, quarter, month);
    }

    protected void btnDownloadReport_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
          EmployeeViewModel employee =UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId=employee.EMPLOYEENO.Length> 0 ?Convert.ToInt32( employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        ReportCycleEnt reportCycle = ESI_ReportDAL.GetReportCycle(employeeId, year, quarter, month);
        if (reportCycle.REPORT_CYCLE_ID <= 0)
        {
            reportCycle.REPORT_CYCLE_ID = 0;
        }

        DataTable dt_excel = ESI_ReportDAL.KpiVsAchievementDownload(employeeId, reportCycle.REPORT_CYCLE_ID);

        Common.ExportToExcel(dt_excel, String.Format("Sales_Incentive_For_{0}_{1}", employeeName, System.DateTime.Now.ToString("ddMMyyy-HHmmss")));

        KPIvsAchievement(year, quarter, month);
    }
    protected void btnDownloadReportArrear1_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
        EmployeeViewModel employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleList(employeeId, year, quarter, month);

        DataTable dt_excel = ESI_ReportDAL.KpiVsAchievementDownload(employeeId, reportCycleList[1].REPORT_CYCLE_ID);

        Common.ExportToExcel(dt_excel, String.Format("Sales_Incentive_For_{0}_{1}", employeeName, System.DateTime.Now.ToString("ddMMyyy-HHmmss")));

        KPIvsAchievement(year, quarter, month);
    }

    protected void btnDownloadReportArrear2_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
        EmployeeViewModel employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleList(employeeId, year, quarter, month);

        DataTable dt_excel = ESI_ReportDAL.KpiVsAchievementDownload(employeeId, reportCycleList[2].REPORT_CYCLE_ID);

        Common.ExportToExcel(dt_excel, String.Format("Sales_Incentive_For_{0}_{1}", employeeName, System.DateTime.Now.ToString("ddMMyyy-HHmmss")));

        KPIvsAchievement(year, quarter, month);
    }

    protected void btnDownloadReportArrear3_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
        EmployeeViewModel employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleList(employeeId, year, quarter, month);

        DataTable dt_excel = ESI_ReportDAL.KpiVsAchievementDownload(employeeId, reportCycleList[3].REPORT_CYCLE_ID);

        Common.ExportToExcel(dt_excel, String.Format("Sales_Incentive_For_{0}_{1}", employeeName, System.DateTime.Now.ToString("ddMMyyy-HHmmss")));

        KPIvsAchievement(year, quarter, month);
    }

    protected void DownloadScoreCard_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
        EmployeeViewModel employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        ReportCycleEnt reportCycle = ESI_ReportDAL.GetReportCycle(employeeId, year, quarter, month);
        if (reportCycle.REPORT_CYCLE_ID <= 0)
        {
            reportCycle.REPORT_CYCLE_ID = 0;
        }

        GenerateKPIScorecard(reportCycle.REPORT_CYCLE_ID);
    }
    protected void btnDownloadScoreCardArrear1_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
        EmployeeViewModel employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleList(employeeId, year, quarter, month);

        GenerateKPIScorecard(reportCycleList[1].REPORT_CYCLE_ID);
    }
    protected void btnDownloadScoreCardArrear2_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
        EmployeeViewModel employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleList(employeeId, year, quarter, month);

        GenerateKPIScorecard(reportCycleList[2].REPORT_CYCLE_ID);
    }
    protected void btnDownloadScoreCardArrear3_Click(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);

        int userId = LoginInfo.Current.UserId;
        EmployeeViewModel employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;

        string employeeName = employee.NAME;
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleList(employeeId, year, quarter, month);

        GenerateKPIScorecard(reportCycleList[3].REPORT_CYCLE_ID);
    }
    public void GenerateKPIScorecard(int reportCycleId)
    {
        try
        {
            DataTable approvallog = ESI_ReportDAL.ESI_GETREPORTSCORECAR_INFO(reportCycleId);
            string fileType = "";
            if (approvallog.Rows.Count > 0)
            {
                if (approvallog.Rows[0]["srcontent"] != DBNull.Value)
                {
                    //if (approvallog.Rows[0]["REPORT_CYCLE_ID"] != DBNull.Value)
                    //{
                    //    approval_log_id = Convert.ToInt32(approvallog.Rows[0]["APPROVAL_STATUS_LOG_ID"]);
                    //}
                    fileType = approvallog.Rows[0]["FTYPE"] as String;
                    byte[] srContent;
                    srContent = approvallog.Rows[0]["srcontent"] as Byte[];
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.ContentType = GetMimeTypeByFileName(fileType);
                    //Response.AppendHeader("content-disposition", String.Format("attachment; filename={0}.{1}", Request["Fname"].ToString(), Request["fileex"].ToString()));
                    Response.AppendHeader("content-disposition", String.Format("inline; filename={0}{1}.{2}", "Scorecard", System.DateTime.Now.ToString("ddMMyyy-HHmmss"), fileType));
                    Response.BinaryWrite(srContent);
                    Response.Flush();
                    Response.End();
                } 
            }
        }
        catch (Exception ex) 
        {
        
        }
    
    }
    public string GetMimeTypeByFileName(string sFileName)
    {
        string sMime = "application/octet-stream";

        string sExtension = "." + sFileName;
        if (!string.IsNullOrEmpty(sExtension))
        {
            sExtension = sExtension.Replace(".", "");
            sExtension = sExtension.ToLower();

            if (sExtension == "xls" || sExtension == "xlsx")
            {
                sMime = "application/ms-excel";
            }
            else if (sExtension == "doc" || sExtension == "docx")
            {
                sMime = "application/msword";
            }
            else if (sExtension == "ppt" || sExtension == "pptx")
            {
                sMime = "application/ms-powerpoint";
            }
            else if (sExtension == "rtf")
            {
                sMime = "application/rtf";
            }
            else if (sExtension == "zip")
            {
                sMime = "application/zip";
            }
            else if (sExtension == "mp3")
            {
                sMime = "audio/mpeg";
            }
            else if (sExtension == "bmp")
            {
                sMime = "image/bmp";
            }
            else if (sExtension == "gif")
            {
                sMime = "image/gif";
            }
            else if (sExtension == "jpg" || sExtension == "jpeg")
            {
                sMime = "image/jpeg";
            }
            else if (sExtension == "png")
            {
                sMime = "image/png";
            }
            else if (sExtension == "tiff" || sExtension == "tif")
            {
                sMime = "image/tiff";
            }
            else if (sExtension == "txt")
            {
                sMime = "text/plain";
            }
            else if (sExtension == "pdf")
            {
                sMime = "application/pdf";
            }
            else if (sExtension == "eml")
            {
                sMime = "application/eml";
            }
        }

        return sMime;
    }
}
