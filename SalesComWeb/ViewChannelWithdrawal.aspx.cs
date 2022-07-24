using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;

public partial class SetupActivity : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex > 0 && this.ddlReportCycle.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlReportName.SelectedValue), int.Parse(ddlReportCycle.SelectedValue));
        }
        else
        {
            lv.DataSource = null;
            lv.DataBind();
            lblResults.Text = "Please select a report type";
            pager.Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.ChannelWithdrawalView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
        }
    }

    private void BindData(int reportId, Int32 reportCycleId)
    {
        List<ChannelWithdrawalEnt> list = ChannelWithdrwalDAL.GetItemList(0, reportId, reportCycleId);

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {

        if (ddlReportName.SelectedIndex > 0 && this.ddlReportCycle.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlReportName.SelectedValue), int.Parse(ddlReportCycle.SelectedValue));
        }
        else
        {
            lv.DataSource = null;
            lv.DataBind();
            lblResults.Text = "Please select a report type";
            pager.Visible = false;
        }

        //BindData(0, 0);
        //pager.SetPageProperties(0, pager.MaximumRows, false);

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ImportChannelWithdrawalList.aspx");
    }
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (this.ddlReportName.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByReportId(ddlReportCycle, int.Parse(ddlReportName.SelectedValue));
            Common.AddSelectOne(ddlReportCycle);
            lv.DataSource = null;
            lv.DataBind();
            lblResults.Text = "Please select a report type";
            pager.Visible = false;
        }

        else
        {
            this.ddlReportCycle.Items.Clear();
        }

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex > 0 && this.ddlReportCycle.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlReportName.SelectedValue), int.Parse(ddlReportCycle.SelectedValue));
        }
        else
        {
            lv.DataSource = null;
            lv.DataBind();
            lblResults.Text = "Please select a report type";
            pager.Visible = false;
        }
    }
 
}