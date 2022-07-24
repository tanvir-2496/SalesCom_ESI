using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingApproval : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (ddlReportPublishedMonth.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlReportPublishedMonth.SelectedValue), 0);
        }
        else
        {
            BindData(0, 0);
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (!Permissions.ReportViewView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Common.PopulatePeriodType(ddlPeridType);
            Common.AddSelectOne(ddlPeridType);
            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();
        }
    }
    private void BindData(int baseMonth, int publishedId)
    {

        List<ReportViewWithMonth> list;

        if (baseMonth == 0 && publishedId == 0)
        {
            list = new List<ReportViewWithMonth>();
        }
        else
        {
            list = ReportViewDAL.ComReportExecusionProvision(baseMonth, publishedId);
        }

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }
  
    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
    {

        string arg = e.CommandArgument.ToString();

        int CycleReportID = Convert.ToInt32(arg);
        int AmountTypeID = 0;

        DataTable dt_excel = CommissionDetailExportDAL.DetailsProvisionReport(AmountTypeID, CycleReportID);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Report_Wise_Provision_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }
    protected void ddlReportPublishedMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlReportPublishedMonth.SelectedIndex > 0)
        {
            pager.SetPageProperties(0, pager.MaximumRows, false);
            BindData(0, int.Parse(ddlReportPublishedMonth.SelectedValue));
        }
        else
        {
            BindData(0, 0);
        }
    }

    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPeridType.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByYear(ddlReportPublishedMonth, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            Common.AddSelectOne(ddlReportPublishedMonth);
        }

        else
        {
            ddlReportPublishedMonth.Items.Clear();
        }
        BindData(0, 0);
    }
    protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        LinkButton _lbtnDetailsAmount = (LinkButton)e.Item.FindControl("lbtnDetailsAmount");
        PostBackTrigger ti = new PostBackTrigger();
        ti.ControlID = _lbtnDetailsAmount.ClientID;
        upCycle.Triggers.Add(ti);
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnDetailsAmount);
    }

}