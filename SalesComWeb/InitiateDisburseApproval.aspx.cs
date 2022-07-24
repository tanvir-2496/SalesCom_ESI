using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingApproval : System.Web.UI.Page
{

    protected int CommissionCycleId
    {
        get { return (int)ViewState["CommissionCycleId"]; }
        set { ViewState["CommissionCycleId"] = value; }
    }


    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (ddlCommissionCycle.SelectedIndex > 0)
        {
            BindData(Int32.Parse(ddlCommissionCycle.SelectedValue));
        }
        else
        {
            BindData(0);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.InitiateDisburseApprovalView)
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

    private void BindData(Int32 commissionCycleId)
    {
        List<InitiateDisburseEnt> list;
        if (commissionCycleId > 0)
        {
            list = InitiateDisburseDAL.GetItemList(commissionCycleId);
        }
        else
        {
            list = new List<InitiateDisburseEnt>();
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
       
        DataTable dt_excel = ClaimApprovalProcessDAL.Get_Com_Claim_Data(CycleReportID);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Report_Details_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }

    protected void ddlCommissionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlCommissionCycle.SelectedIndex > 0)
        {
            pager.SetPageProperties(0, pager.MaximumRows, false);
            BindData(Int32.Parse(ddlCommissionCycle.SelectedValue));
        }
        else
        {
            BindData(0);
        }
    }

    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPeridType.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByYear(ddlCommissionCycle, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            Common.AddSelectOne(ddlCommissionCycle);
        }
        else
        {
            ddlCommissionCycle.Items.Clear();
        }
        BindData(0);
    }
    protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        LinkButton _lbtnDetailsAmount = (LinkButton)e.Item.FindControl("lbtnDetailsAmount");
        PostBackTrigger ti = new PostBackTrigger();
        ti.ControlID = _lbtnDetailsAmount.ClientID;
        upCycle.Triggers.Add(ti);
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnDetailsAmount);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        if (ddlCommissionCycle.SelectedIndex > 0)
        {
            BindData(Int32.Parse(ddlCommissionCycle.SelectedValue));
        }
        else
        {
            BindData(0);
        }
    }
}