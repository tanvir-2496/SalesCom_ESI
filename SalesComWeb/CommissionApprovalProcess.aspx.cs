using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class CommissionApprovalProcess : System.Web.UI.Page
{

    protected Int32 Id
    {
        get { return (Int32)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected Int32 ReportCycleId
    {
        get { return (Int32)ViewState["ReportCycleId"]; }
        set { ViewState["ReportCycleId"] = value; }
    }

    protected Int16 FlowId
    {
        get { return (Int16)ViewState["FlowId"]; }
        set { ViewState["FlowId"] = value; }
    }

    protected Int16 ClaimFlowId
    {
        get { return (Int16)ViewState["ClaimFlowId"]; }
        set { ViewState["ClaimFlowId"] = value; }
    }

    protected Int16 LevelId
    {
        get { return (Int16)ViewState["LevelId"]; }
        set { ViewState["LevelId"] = value; }
    }

    protected Int16 OrderId
    {
        get { return (Int16)ViewState["OrderId"]; }
        set { ViewState["OrderId"] = value; }
    }

    protected string PublishCycle
    {
        get { return (string)ViewState["PublishCycle"]; }
        set { ViewState["PublishCycle"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.PendingApprovalViewView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Id = -1;

            if (!string.IsNullOrEmpty(Request["ID"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                ReportCycleId = int.Parse(Request.QueryString["RCI"]);
                ClaimFlowId = Int16.Parse(Request.QueryString["CID"]);
                FlowId = Int16.Parse(Request.QueryString["FID"]);
                LevelId = Int16.Parse(Request.QueryString["LID"]);
                OrderId = Int16.Parse(Request.QueryString["OID"]);
                lblReportName.Text = Request.QueryString["RN"];
                lblBaseCycle.Text = Request.QueryString["RC"];
                PublishCycle = Request.QueryString["RPC"];
                lblCommissionAmt.Text = Request.QueryString["COM"];
                lblApprovalLevelName.Text = Request.QueryString["LN"];

                GetApprovalHistory();
            }
        }
    }

    private void GetApprovalHistory()
    {
        List<ApprovalHistory> approvalHistory = commission_approval_dal.GetCommissionApprovalHistory(Id,1);
        lv.DataSource = approvalHistory;
        lv.DataBind();
    }

    private void ClearData()
    {
        Id = -1;
        txtComments.Text = String.Empty;
        string script = "$(document).ready(function() {tb_remove();});";
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", script, true);
    }

    private int SaveData(Boolean IsAcept)
    {
        commission_approval_ent ad = new commission_approval_ent() { id = Id, report_cycle_id = ReportCycleId, report_name = lblReportName.Text, base_moth = lblBaseCycle.Text, publish_month = PublishCycle, com_amount = lblCommissionAmt.Text, flow_id = FlowId, claim_flow_id = ClaimFlowId, level_id = LevelId, current_level = lblApprovalLevelName.Text, order_id = OrderId, comments = txtComments.Text ?? String.Empty };
        return commission_approval_dal.UpdateComAppStatus(ad, IsAcept == true ? (Int16)1 : (Int16)2, LoginInfo.Current.UserId, LoginInfo.Current.UserName);
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData(true);
        ScriptManager.RegisterStartupScript(this, typeof(string), "Successful", "alert('Information updated successfully.');", true);

        if (ErrorCode >= 0)
        {
            ClearData();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('Failed to updated.');", true);
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "parent.tb_remove();", true);
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData(false);
        ScriptManager.RegisterStartupScript(this, typeof(string), "Successful", "alert('Information updated successfully.');", true);

        if (ErrorCode >= 0)
        {
            ClearData();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('Failed to updated.');", true);
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "parent.tb_remove();", true);
    }


}