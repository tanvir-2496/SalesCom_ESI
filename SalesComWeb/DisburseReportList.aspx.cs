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
            if (!Permissions.DisburseReportView)
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

    private void BindData(int commissionCycleId)
    {
        List<DisburseReportListEnt> list;
        if (commissionCycleId > 0)
        {
            list = DisburseReportListDAL.GetItemList(commissionCycleId);
        }
        else
        {
            list = new List<DisburseReportListEnt>();
        }
        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }


    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string[] arg = e.CommandArgument.ToString().Split('|');

        int CycleReportID = Convert.ToInt32(arg[0]);

        string fileName = string.Empty;

        DataTable dt_excel = null;

        if (e.CommandName.Equals("DetailsAmount"))
        {
            fileName = String.Format("Disburse_Details_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss"));
            dt_excel = DisburseApprovalProcessDAL.Get_Final_Disburse_Details(CycleReportID, arg[1], arg[2]);
        }
        else if (e.CommandName.Equals("PosUploadDetails"))
        {
            fileName = String.Format("POS_Upload_Details_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss"));
            dt_excel = DisburseApprovalProcessDAL.Get_POS_Upload_Details(CycleReportID);
        }

        try
        {
            Common.ExportToExcel(dt_excel, fileName);
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
        LinkButton _lbtnPosUploadDetails = (LinkButton)e.Item.FindControl("lbtnPosUploadDetails");
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnDetailsAmount);
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnPosUploadDetails);

        //PostBackTrigger ti = new PostBackTrigger();
        //ti.ControlID = _lbtnDetailsAmount.ClientID;
        //upCycle.Triggers.Add(ti);
        //PostBackTrigger ptPos = new PostBackTrigger();
        //ptPos.ControlID = _lbtnPosUploadDetails.ClientID;
        //upCycle.Triggers.Add(ptPos);
    }


}