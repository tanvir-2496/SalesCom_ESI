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
        BindDataToGrid();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.DisburseApprovalProcessView)
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

    private void BindData(DataGetType dataGetType)
    {
        List<DisburseApprovalProcessEnt> list;

        if (dataGetType == DataGetType.All)
        {
            list = DisburseApprovalProcessDAL.GetItemList(LoginInfo.Current.UserId, 0, Int32.Parse(this.ddlPeridType.SelectedValue));
        }
        else if (dataGetType == DataGetType.Cycle)
        {
            list = DisburseApprovalProcessDAL.GetItemList(LoginInfo.Current.UserId, Int32.Parse(ddlCommissionCycle.SelectedValue), Int32.Parse(this.ddlPeridType.SelectedValue));
        }
        else
        {
            list = new List<DisburseApprovalProcessEnt>();
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
        
        DataTable dt_excel = DisburseApprovalProcessDAL.Get_Disburse_Data(CycleReportID);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Disburse_Details_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }

    protected void ddlCommissionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDataToGrid();
    }

    private void BindDataToGrid()
    {
        if (this.ddlCommissionCycle.SelectedIndex == 1)
        {
           // pager.SetPageProperties(0, pager.MaximumRows, false);
            BindData(DataGetType.All);
        }
        else if (this.ddlCommissionCycle.SelectedIndex > 1)
        {
            pager.SetPageProperties(0, pager.MaximumRows, false);
            BindData(DataGetType.Cycle);
        }
        else
        {
            BindData(DataGetType.None);
        }
    }

    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPeridType.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByYear(ddlCommissionCycle, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            if (ddlCommissionCycle.Items.Count > 0)
            {
                Common.AddSelectAll(ddlCommissionCycle);
                Common.InsertSelectOne(ddlCommissionCycle);
            }
        }
        else
        {
            ddlCommissionCycle.Items.Clear();
        }
        BindData(DataGetType.None);
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
        BindDataToGrid();
    }


    enum DataGetType { All, Cycle, None };


}