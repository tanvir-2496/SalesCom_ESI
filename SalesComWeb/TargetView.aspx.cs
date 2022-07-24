using ESI.DAL;
using ESI.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class TargetView : System.Web.UI.Page
{
    protected Int32 Id
    {
        get { return (Int32)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ESITargetView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                lblReportName.Text = Request.QueryString["RN"];
                int month = int.Parse(Request.QueryString["Month"]);

                GetTargetList(month);
            }
        }

    }

    private void GetTargetList(int month)
    {
        try
        {
            List<TargetListEnt> TargetList = ESI_TargetListDAL.GetTargetList(Id, month).OrderBy(x => x.kpi_name).OrderBy(x => x.sub_kpi_name).ToList();
            lv.DataSource = TargetList;
            lv.DataBind();
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }

    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e) 
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

        int KpiId = Convert.ToInt32(commandArgs[0]);
        int month = Convert.ToInt32(commandArgs[1]);

        int reportCycleId = Id;

        try
        {
            DataTable dt_excel = ESI_ReportExportDAL.DetailsKpiWiseTargetReport(reportCycleId, KpiId, month);
            Common.ExportToExcel(dt_excel, String.Format("Detail_Target_Report_Month_{1}_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss"), month));
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }

    }

    protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        LinkButton _lbtnDetailsAmount = (LinkButton)e.Item.FindControl("lbtnDetailsAmount");
        PostBackTrigger ti = new PostBackTrigger();
        ti.ControlID = _lbtnDetailsAmount.ClientID;
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnDetailsAmount);
    }

    public static string ChangeSalaryType(double salaryType)
    {
        string number = salaryType.ToString("N");
        return number.Substring(0, number.Length - 3);
    }

    public bool GetApproveDRejectPermission(int level_id)
    {
        int numPermission = ESI_PermissionDAL.getRolePermission(LoginInfo.Current.UserId, level_id);

        if (numPermission == 0)
        {
            return false;
        }
        return true;
    }

    protected void btnDownloadTarget_Click(object sender, EventArgs e)
    {
        try
        {
            int reportCycleId = Id;
            DataTable dt_excel = ESI_ReportExportDAL.DetailsKpiWiseTargetReport(reportCycleId, 0, 0);
            Common.ExportToExcel(dt_excel, String.Format("Detail_Target_Report_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }
}