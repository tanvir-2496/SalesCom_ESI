using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingApproval : System.Web.UI.Page
{

    protected Int32 ReportId
    {
        get { return (Int32)ViewState["ReportId"]; }
        set { ViewState["ReportId"] = value; }
    }

    protected string ReportName
    {
        get { return (String)ViewState["ReportName"]; }
        set { ViewState["ReportName"] = value; }
    }

    protected DateTime StartDate
    {
        get { return (DateTime)ViewState["StartDate"]; }
        set { ViewState["StartDate"] = value; }
    }

    protected DateTime EndDate
    {
        get { return (DateTime)ViewState["EndDate"]; }
        set { ViewState["EndDate"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.AdhocSummaryReportView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Common.PopulateAdHocReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
        }
    }

    private void BindData(Int32 reportId, DateTime startDate, DateTime endDate)
    {
        List<AdHocSummaryReport> list = AdHocPendingApprovalDAL.GetAdHocSummaryReport(reportId, startDate, endDate);
        lv.DataSource = list;
        lv.DataBind();
    }

    protected void lv_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
    {
        Export export = new Export();
        DataTable dt_excel = CommissionDetailExportDAL.AdHocSummaryDetailReport(ReportId, StartDate, EndDate);
        try
        {
            Common.ExportToExcel(dt_excel, String.Format("{0}-{1}", ReportName.Replace(" ", "_"), System.DateTime.Now.ToString("ddMMMyy")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }
    protected void lv_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
    {
        LinkButton _lbtnDetailsAmount = (LinkButton)e.Item.FindControl("lbtnDetailsAmount");
        PostBackTrigger ti = new PostBackTrigger();
        ti.ControlID = _lbtnDetailsAmount.ClientID;
        upCycle.Triggers.Add(ti);
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnDetailsAmount);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (this.ddlReportName.SelectedIndex > 0)
        {
            this.StartDate = DateTime.Parse(txtFromDate.Text);
            this.EndDate = DateTime.Parse(txtToDate.Text);
            ReportId = Int32.Parse(ddlReportName.SelectedValue);
            ReportName = ddlReportName.SelectedItem.Text;
            BindData(ReportId, StartDate, EndDate);
        }
        else
        {
            lv.DataSource = null;
            lv.DataBind();
        }
    }


}