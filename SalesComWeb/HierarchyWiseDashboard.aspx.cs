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
using System.Web.UI.WebControls;

public partial class HierarchyWiseDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESIHierarchyWiseDashboard)
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
            if (y != null) y.Selected = true;
            quarter = DateTime.Now.Month % 3 == 0 ? DateTime.Now.Month / 3 : DateTime.Now.Month / 3 + 1;
            var q = ddlQuarter.Items.FindByValue(quarter.ToString());
            if (q != null) q.Selected = true;
            DropDownLoad();
            int userId = LoginInfo.Current.UserId;
            int selfEmployeeId = UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO.Length > 0 ? Convert.ToInt32(UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO) : 0;
            int designationLevel = ESI_ReportDAL.GetUserDesignation(selfEmployeeId);

            ddlSalesChannel.DataSource = ESI_ReportDAL.GetALLSALESCHANNEL();
            ddlSalesChannel.DataTextField = "sales_channel_name";
            ddlSalesChannel.DataValueField = "sales_channel_id";
            ddlSalesChannel.DataBind();
            ddlSalesChannel.Items.Insert(0, new ListItem("[Select One]", "0"));
           
            KPIvsAchievement(year, quarter, month, designationLevel, selfEmployeeId);
        }

    }
    protected void DropDownLoad()
    {
        int userId = LoginInfo.Current.UserId;
        var employee = UserMappDAL.GetEmployeeByUserId(userId);
        int employeeId = employee.EMPLOYEENO.Length > 0 ? Convert.ToInt32(employee.EMPLOYEENO) : 0;
       
        #region CXO_Role
        int CXO_Role = Common.PopulateCXODirectorRoles(ddl_CXO_Role, employeeId);
        if (CXO_Role < 1)
        {
            lbl_ddl_CXO_Role.Attributes["style"] = "display: none;";
        }
        else
        {
            lbl_ddl_CXO_Role.Attributes["style"] = "";
        }
        #endregion

        #region ClusterDirectors
        int ClusterDirector = Common.PopulateHoDnDirectorRoles(ddlHoDnDirectorRoles, employeeId);
        if (ClusterDirector < 1)
        {
            Div_HoDnDirectorRoles.Attributes["style"] = "display: none;";
        }
        else
        {
            Div_HoDnDirectorRoles.Attributes["style"] = "";
        }
        #endregion

        #region  Regional Head
        int RegionalHeadList = Common.PopulateRegionalHead(ddlRegionalHead, employeeId);
        if (RegionalHeadList < 1)
        {
            Div_RegionalHead.Attributes["style"] = "display: none;";
        }
        else
        {
            Div_RegionalHead.Attributes["style"] = "";
        }
        #endregion

        #region  Sales Employee Roles
        int SalesEmployeeList = Common.PopulateSalesEmployeeRoles(ddlSalesEmployee, employeeId);
        if (SalesEmployeeList < 1)
        {
            Div_Sales_Employee.Attributes["style"] = "display: none;";
        }
        else
        {
            Div_Sales_Employee.Attributes["style"] = "";
        }
        #endregion

    }
    protected void ddl_CXO_RoleSelectedIndexChanged(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int EmployeeId = ddl_CXO_Role.SelectedIndex > 0 ? Convert.ToInt32(ddl_CXO_Role.SelectedValue) : 0;
        int userId = LoginInfo.Current.UserId;
        int designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
        #region ClusterDirectors
        if (EmployeeId > 0)
        {
            int ClusterDirector = Common.PopulateHoDnDirectorRoles(ddlHoDnDirectorRoles, EmployeeId);
            if (ClusterDirector < 1)
            {
                Div_HoDnDirectorRoles.Attributes["style"] = "display: none;";
                ddlHoDnDirectorRoles.Attributes["style"] = "display: none;";
                ddlRegionalHead.Attributes["style"] = "display: none;";
                Div_RegionalHead.Attributes["style"] = "display: none;";
                Div_Sales_Employee.Attributes["style"] = "display: none;";
                ddlSalesEmployee.Attributes["style"] = "display: none;";
            }
            else
            {
                Div_HoDnDirectorRoles.Attributes["style"] = "";
            }
        }
        else
        {
            Div_HoDnDirectorRoles.Attributes["style"] = "display: none;";
            ddlHoDnDirectorRoles.Attributes["style"] = "display: none;";
            ddlRegionalHead.Attributes["style"] = "display: none;";
            Div_RegionalHead.Attributes["style"] = "display: none;";
            Div_Sales_Employee.Attributes["style"] = "display: none;";
            ddlSalesEmployee.Attributes["style"] = "display: none;";

            EmployeeId = UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO.Length > 0 ? Convert.ToInt32(UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO) : 0;
            designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
        }
        #endregion

        KPIvsAchievement(year, quarter, month, designationLevel, EmployeeId);
    }
    protected void ddl_HoDnDirectorRolesSelectedIndexChanged(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int userId = LoginInfo.Current.UserId;
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);
        int EmployeeId = ddlHoDnDirectorRoles.SelectedIndex > 0 ? Convert.ToInt32(ddlHoDnDirectorRoles.SelectedValue) : 0;
        int designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
        #region  Regional Head
        if (EmployeeId > 0)
        {
            int RegionalHeadList = Common.PopulateRegionalHead(ddlRegionalHead, EmployeeId);
            if (RegionalHeadList < 1)
            {
                Div_RegionalHead.Attributes["style"] = "display: none;";
                ddlRegionalHead.Attributes["style"] = "display: none;";

                ddlSalesEmployee.Attributes["style"] = "display: none;";
                Div_Sales_Employee.Attributes["style"] = "display: none;";
            }
            else
            {
                Div_RegionalHead.Attributes["style"] = "";
            }
        }
        else
        {
            Div_RegionalHead.Attributes["style"] = "display: none;";
            ddlRegionalHead.Attributes["style"] = "display: none;";

            ddlSalesEmployee.Attributes["style"] = "display: none;";
            Div_Sales_Employee.Attributes["style"] = "display: none;";

            EmployeeId = ddl_CXO_Role.SelectedIndex > 0 ? Convert.ToInt32(ddl_CXO_Role.SelectedValue) : 0;
            designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
        }
        #endregion
       
        KPIvsAchievement(year, quarter, month, designationLevel, EmployeeId);
        
    }
    protected void ddl_RegionalHeadSelectedIndexChanged(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);
        int userId = LoginInfo.Current.UserId;
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int EmployeeId = ddlRegionalHead.SelectedIndex > 0 ? Convert.ToInt32(ddlRegionalHead.SelectedValue) : 0;
        int designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
        #region  Sales Employee Roles
        if (EmployeeId > 0)
        {
            int SalesEmployeeList = Common.PopulateSalesEmployeeRoles(ddlSalesEmployee, EmployeeId);
            if (SalesEmployeeList < 1)
            {
                ddlSalesEmployee.Attributes["style"] = "display: none;";
                Div_Sales_Employee.Attributes["style"] = "display: none;";
            }
            else
            {
                Div_Sales_Employee.Attributes["style"] = "";
            }
        }
        else
        {
            ddlSalesEmployee.Attributes["style"] = "display: none;";
            Div_Sales_Employee.Attributes["style"] = "display: none;";

            EmployeeId = ddlHoDnDirectorRoles.SelectedIndex > 0 ? Convert.ToInt32(ddlHoDnDirectorRoles.SelectedValue) : 0;
            designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
        }
        #endregion

        KPIvsAchievement(year, quarter, month, designationLevel, EmployeeId);
       
    }
    protected void ddl_SalesEmployeeSelectedIndexChanged(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int EmployeeId = ddlSalesEmployee.SelectedIndex > 0 ? Convert.ToInt32(ddlSalesEmployee.SelectedValue) : 0;
        int designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
        KPIvsAchievement(year, quarter, month, designationLevel, EmployeeId);
       
    }
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)//To Do: 
    {
        int year = Convert.ToInt32(ddlYear.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int EmployeeId = 0;
        int Sales_EmployeeId = ddlSalesEmployee.SelectedIndex > 0 ? Convert.ToInt32(ddlSalesEmployee.SelectedValue) : 0;
        int Region_EmployeeId = ddlRegionalHead.SelectedIndex > 0 ? Convert.ToInt32(ddlRegionalHead.SelectedValue) : 0;
        int HodDirector_EmployeeId = ddlHoDnDirectorRoles.SelectedIndex > 0 ? Convert.ToInt32(ddlHoDnDirectorRoles.SelectedValue) : 0;
        int Cox_EmployeeId = ddl_CXO_Role.SelectedIndex > 0 ? Convert.ToInt32(ddl_CXO_Role.SelectedValue) : 0;

        EmployeeId = Cox_EmployeeId > 0 ? Cox_EmployeeId : HodDirector_EmployeeId > 0 ? HodDirector_EmployeeId : Region_EmployeeId > 0 ? Region_EmployeeId : Sales_EmployeeId > 0 ? Sales_EmployeeId : 0;


        int userId = LoginInfo.Current.UserId;
        int selfFmployeeId = UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO.Length > 0 ? Convert.ToInt32(UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO) : 0;

        if (EmployeeId > 0)
        {
            int designationLevel = ESI_ReportDAL.GetUserDesignation(EmployeeId);
            KPIvsAchievement(year, quarter, month, designationLevel, EmployeeId);
        }
        else
        {
            int designationLevel = ESI_ReportDAL.GetUserDesignation(selfFmployeeId);
            KPIvsAchievement(year, quarter, month, designationLevel, selfFmployeeId);

        }
    }

    public void KPIvsAchievement(int year, int quarter, int month, int designation, int employeeId)
    {
        int userId = LoginInfo.Current.UserId;
        int selfEmployeeId = UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO.Length > 0 ? Convert.ToInt32(UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO) : 0;

        int salesChannelId = Convert.ToInt32(ddlSalesChannel.SelectedValue);
        List<ReportCycleEnt> reportCycleList = ESI_ReportDAL.GetReportCycleListBuSalesChannel(salesChannelId, year, quarter, month);
        List<KPIvsAchievementForHigherEnt> report = new List<KPIvsAchievementForHigherEnt>();
        List<KPIvsAchievementForHigherEnt> arrearReport1 = new List<KPIvsAchievementForHigherEnt>();
        List<KPIvsAchievementForHigherEnt> arrearReport2 = new List<KPIvsAchievementForHigherEnt>();
        List<KPIvsAchievementForHigherEnt> arrearReport3 = new List<KPIvsAchievementForHigherEnt>();
        
        Arrear1lvl.Visible = false;
        Arrear2lvl.Visible = false;
        Arrear3lvl.Visible = false;
        if (reportCycleList.Count() > 0)
        {
            report = ESI_ReportDAL.KPIvsAchievementForAll(selfEmployeeId, employeeId, reportCycleList[0].REPORT_CYCLE_ID, designation);
            
        }
        lv.DataSource = report;
        lv.DataBind();

        if (reportCycleList.Count() > 1)
        {
            arrearReport1 = ESI_ReportDAL.KPIvsAchievementForAll(selfEmployeeId, employeeId, reportCycleList[1].REPORT_CYCLE_ID, designation);
            if (arrearReport1.Count() > 0)
            {
                Arrear1lvl.Visible = true;

            }
        }
        Arrear1lv.DataSource = arrearReport1;
        Arrear1lv.DataBind();

        if (reportCycleList.Count() > 2)
        {
            arrearReport2 = ESI_ReportDAL.KPIvsAchievementForAll(selfEmployeeId, employeeId, reportCycleList[2].REPORT_CYCLE_ID, designation);
            if (arrearReport2.Count() > 0)
            {
                Arrear2lvl.Visible = true;

            }
        }
        Arrear2lv.DataSource = arrearReport2;
        Arrear2lv.DataBind();

        if (reportCycleList.Count() > 3)
        {
            arrearReport3 = ESI_ReportDAL.KPIvsAchievementForAll(selfEmployeeId, employeeId, reportCycleList[3].REPORT_CYCLE_ID, designation);
            if (arrearReport3.Count() > 0)
            {
                Arrear3lvl.Visible = true;

            }
        }
        Arrear3lv.DataSource = arrearReport3;
        Arrear3lv.DataBind();
        

        #region Chart Start
        if (report.Count <= 0)
        {
            KPIChart.Visible = false;
            KPIChart.Controls.Clear();
        }
        else
        {
            KPIChart.Visible = true;
            KPIChart.Titles.Clear();
        }
        KPIChart.ChartAreas["KPIName"].AxisX.Interval = 1;
        KPIChart.DataSource = report;
        KPIChart.Series[0].XValueMember = "KPIName";
        KPIChart.Series[0].YValueMembers = "TotalQuarterAchievement";
        KPIChart.DataBind();
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
    

}
