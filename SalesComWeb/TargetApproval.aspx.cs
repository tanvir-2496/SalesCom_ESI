using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESI.DAL;
using SalesCom.Entity;
using ESI.Entity;
using SalesCom.DAL;
using ESI.Entity.ViewModel;

public partial class TargetApproval : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        try 
        {
            int reportType = Convert.ToInt32(ddlReportType.SelectedValue);
            int salesGroup = Convert.ToInt32(ddlSalesGroup.SelectedValue);
            int salesChannelId = Convert.ToInt32(ddlSalesChannel.SelectedValue);
            int year = Convert.ToInt32(ddlYear.SelectedItem.Text);
            int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
            int month = Convert.ToInt32(ddlMonth.SelectedValue);
            BindData(LoginInfo.Current.UserId, salesGroup, reportType, salesChannelId, year, quarter, month);        
        }
        catch (Exception ex)
        {
            BindData(LoginInfo.Current.UserId, 0, 0, 0, 0, 0, 0);
        }
        
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESITargetApproval)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            pager.PageSize = 15;
            var userId = LoginInfo.Current.UserId;
            Common.PopulateSalesGroup(ddlSalesGroup, userId);

            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();
            BindData(LoginInfo.Current.UserId, 0, 0, 0, 0, 0, 0);
        }

        pager.PageSize = 15;
    }

    private void BindData(int userId, int salesGroup, int reportType, int channelId, int year, int quarter, int month)
    {
        try
        {
            List<kpi_approval_ent> list = new List<kpi_approval_ent>();
            list = kpi_approval_dal.GetItemList(userId, salesGroup, reportType, channelId, year, quarter, month, "ESI_GETRPTCYCLEBYSCHIDQTRYTRGT");
            lv.DataSource = list;
            lv.DataBind();
            lblResults.Text = String.Format("Total results: {0}", list.Count);
            pager.Visible = list.Count > pager.PageSize;
        }
        catch (Exception ex)
        {
            this.lblResults.Text = "Error Occured!!!";
        }
    }

    protected void ddl_SalesGroup_IndexChanged(object sender, EventArgs e)
    {
        int salesGroup = Convert.ToInt32(ddlSalesGroup.SelectedValue);
        Common.PopulateSalesChannel(ddlSalesChannel, salesGroup);
        ddlReportType.SelectedValue = "0";
        ddlSalesChannel.SelectedValue = "0";
        ddlSalesChannel.SelectedValue = "0";
        ddlQuarter.SelectedValue = "0";
        ddlMonth.SelectedValue = "0";
        BindData(LoginInfo.Current.UserId, salesGroup, 0, 0, 0, 0, 0);
    }

    public static bool CheckApprovalPermission(int level_id)
    {
        int numPermission = ESI_PermissionDAL.getRolePermission(LoginInfo.Current.UserId, level_id);

        if (numPermission == 0)
        {
            return false;
        }
        return true;
    }

    public static bool CheckLevelPermission(string level)
    {
        if (level.Contains("Target") == false)
        {
            return false;
        }
        return true;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData(LoginInfo.Current.UserId, 0, 0, 0, 0, 0, 0);
        pager.SetPageProperties(0, pager.MaximumRows, false);
        ClearData();
    }

    private void ClearData()
    {
        ddlSalesChannel.SelectedIndex = -1;
        ddlYear.SelectedIndex = -1;
        ddlQuarter.SelectedIndex = -1;
    }

    protected void ddl_IndexChanged(object sender, EventArgs e)
    {
        int reportType = Convert.ToInt32(ddlReportType.SelectedValue);
        int salesGroup = Convert.ToInt32(ddlSalesGroup.SelectedValue);
        int salesChannelId = Convert.ToInt32(ddlSalesChannel.SelectedValue);
        int year = Convert.ToInt32(ddlYear.SelectedItem.Text);
        int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
        int month = Convert.ToInt32(ddlMonth.SelectedValue);
        BindData(LoginInfo.Current.UserId, salesGroup, reportType, salesChannelId, year, quarter, month);
    }

    public static bool CheckExpireMonth(string report_month, string month_no)
    {
        bool disable = false;

        if (Convert.ToInt16(report_month) > 0 && report_month != month_no)
        {
            disable = true;
        }
        return disable;
    }
}