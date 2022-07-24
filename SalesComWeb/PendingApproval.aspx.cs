using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class PendingApproval : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        GetPreRenderData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.PendingApprovalView)
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

    private void BindData(DatFetchType dataFetchType)
    {
        List<commission_approval_ent> list = new List<commission_approval_ent>();

        if (dataFetchType == DatFetchType.All)
        {
            list = commission_approval_dal.GetItemList(0, LoginInfo.Current.UserId, 0, 0);
        }
        else if (dataFetchType == DatFetchType.Cycle)
        {
            list = commission_approval_dal.GetItemList(0, LoginInfo.Current.UserId, int.Parse(ddlCommissionCycle.SelectedValue), 0);
        }
        else if (dataFetchType == DatFetchType.Published)
        {
            list = commission_approval_dal.GetItemList(0, LoginInfo.Current.UserId, 0, int.Parse(ddlReportPublishedMonth.SelectedValue));
        }

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;

    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        GetPreRenderData();
    }

    protected void ddlCommissionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.SetPageProperties(0, pager.MaximumRows, false);
        if (this.ddlCommissionCycle.SelectedIndex > 0)
        {
            this.ddlReportPublishedMonth.SelectedIndex = 0;

            if (this.ddlCommissionCycle.SelectedIndex == 1)
            {
                BindData(DatFetchType.All);
                ChangeYearText(true);
            }
            else
            {
                BindData(DatFetchType.Cycle);
                ChangeYearText(false);
            }
        }
        else
        {
            BindData(DatFetchType.None);
            ChangeYearText(false);
        }
    }

    protected void ddlReportPublishedMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.SetPageProperties(0, pager.MaximumRows, false);
        if (ddlReportPublishedMonth.SelectedIndex > 0)
        {
            this.ddlCommissionCycle.SelectedIndex = 0;

            if (ddlReportPublishedMonth.SelectedIndex == 1)
            {
                BindData(DatFetchType.All);
                ChangeYearText(true);
            }
            else
            {
                BindData(DatFetchType.Published);
                ChangeYearText(false);
            }
        }
        else
        {
            BindData(DatFetchType.None);
            ChangeYearText(false);
        }
    }

    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (this.ddlPeridType.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByYear(ddlCommissionCycle, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            Common.AddSelectAll(ddlCommissionCycle);
            Common.InsertSelectOne(ddlCommissionCycle);

            Common.PopulateCommissionCycleByYear(ddlReportPublishedMonth, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            Common.AddSelectAll(ddlReportPublishedMonth);
            Common.InsertSelectOne(ddlReportPublishedMonth);
        }
        else
        {
            ddlCommissionCycle.Items.Clear();
            ddlReportPublishedMonth.Items.Clear();
        }

        BindData(DatFetchType.None);
        ChangeYearText(false);
    }

    private void GetPreRenderData()
    {
        if (ddlReportPublishedMonth.SelectedIndex > 0)
        {
            this.ddlCommissionCycle.SelectedIndex = 0;

            if (ddlReportPublishedMonth.SelectedIndex == 1)
            {
                BindData(DatFetchType.All);
                ChangeYearText(true);
            }
            else
            {
                BindData(DatFetchType.Published);
                ChangeYearText(false);
            }
        }
        else if (this.ddlCommissionCycle.SelectedIndex > 0)
        {
            this.ddlReportPublishedMonth.SelectedIndex = 0;

            if (this.ddlCommissionCycle.SelectedIndex == 1)
            {
                BindData(DatFetchType.All);
                ChangeYearText(true);
            }
            else
            {
                BindData(DatFetchType.Cycle);
                ChangeYearText(false);
            }
        }
        else
        {
            BindData(DatFetchType.None);
            ChangeYearText(false);
        }
    }

    private void ChangeYearText(bool isAll)
    {
        if (isAll)
        {
            ListItem item = this.ddlYear.SelectedItem;
            item.Text = "[All]";
            this.ddlYear.Enabled = false;
        }
        else
        {
            ListItem item = this.ddlYear.SelectedItem;
            item.Text = item.Value;
            this.ddlYear.Enabled = true;
        }
    }

    public enum DatFetchType { All, Cycle, Published, None }
}