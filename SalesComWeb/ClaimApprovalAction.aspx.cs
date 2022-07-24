using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class CommissionApprovalProcess : System.Web.UI.Page
{



    protected int Id
    {
        get { return (int)ViewState["Id"]; }
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

    protected Int16 DisburseFlowId
    {
        get { return (Int16)ViewState["DisburseFlowId"]; }
        set { ViewState["DisburseFlowId"] = value; }
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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ClaimApprovalOperation)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Id = -1;

            if (!string.IsNullOrEmpty(Request["ID"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                ReportCycleId = int.Parse(Request.QueryString["RCID"]);
                DisburseFlowId = Int16.Parse(Request.QueryString["DFID"]);
                FlowId = Int16.Parse(Request.QueryString["FID"]);
                LevelId = Int16.Parse(Request.QueryString["LID"]);
                OrderId = Int16.Parse(Request.QueryString["OID"]);
                lblReportName.Text = Request.QueryString["RN"];
                lblReportDuration.Text = Request.QueryString["RD"];
                lblCommissionAmt.Text = Request.QueryString["RAM"];
                lblDiscard.Text = Request.QueryString["DAM"];
                lblClaim.Text = Request.QueryString["CAM"];
                lblApprovalLevelName.Text = Request.QueryString["LN"];

                GetApprovalHistory();
            }
        }
    }

    private void GetApprovalHistory()
    {
        List<ApprovalHistory> approvalHistory = commission_approval_dal.GetCommissionApprovalHistory(Id, 2);
        lv.DataSource = approvalHistory;
        lv.DataBind();
    }

    private void ClearData()
    {
        Id = -1;
        txtComments.Text = String.Empty;
    }

    private int SaveData(Boolean IsAcept)
    {
        ClaimApprovalProcessEnt cap= new ClaimApprovalProcessEnt() { Id = Id, report_cycle_id = ReportCycleId, reportname = lblReportName.Text, report_duration = lblReportDuration.Text, report_amt = lblCommissionAmt.Text, flow_id = FlowId, disburse_flow_id = DisburseFlowId, level_id = LevelId, level_name = lblApprovalLevelName.Text, orderid = OrderId, claim_amt = lblClaim.Text, discard_amt= lblDiscard.Text  };
        return ClaimApprovalProcessDAL.UpdateClaimAppStatus(cap, IsAcept == true ? (Int16)1 : (Int16)2, this.txtComments.Text ?? String.Empty, LoginInfo.Current.UserId, LoginInfo.Current.UserName);
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