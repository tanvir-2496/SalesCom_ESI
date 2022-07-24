using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdHocReportView : System.Web.UI.Page
{

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

    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            BindData(StartDate, EndDate);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.AdhocReportViewView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            this.txtFromDate.Text = System.DateTime.Now.AddDays(-5).ToString("dd'-'MM'-'yyyy");
            this.txtToDate.Text = System.DateTime.Now.ToString("dd'-'MM'-'yyyy");
            Common.PopulateAdHocReportList(this.ddlReportname);
            Common.AddSelectAll(this.ddlReportname);

        }
    }

    private void BindData(DateTime startDate, DateTime endDate)
    {
        List<AdHocReportViewEnt> list = AdHocPendingApprovalDAL.GetAdHocReport(int.Parse(this.ddlReportname.SelectedValue), startDate, endDate);
        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void lv_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
    {
        string[] arg = e.CommandArgument.ToString().Split(new char[] { ',' });
        int ReportID = Convert.ToInt32(arg[0]);
        int CycleId = Convert.ToInt32(arg[1]);

        Export export = new Export();

        DataTable dt_excel = CommissionDetailExportDAL.AdHocDetailReport(ReportID, CycleId);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Detail_Report_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
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
        this.StartDate = DateTime.Parse(txtFromDate.Text);
        this.EndDate = DateTime.Parse(txtToDate.Text);
        BindData(StartDate, EndDate);
    }


}