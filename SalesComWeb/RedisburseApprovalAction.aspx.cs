using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RedisburseApprovalAction : System.Web.UI.Page
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
            if (!Permissions.RedisburseApprovalProcessAction)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Id = -1;

            if (!string.IsNullOrEmpty(Request["ID"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                ReportCycleId = int.Parse(Request.QueryString["RCID"]);
                FlowId = Int16.Parse(Request.QueryString["FID"]);
                LevelId = Int16.Parse(Request.QueryString["LID"]);
                OrderId = Int16.Parse(Request.QueryString["OID"]);
                lblReportName.Text = Request.QueryString["RN"];
                lblReportDuration.Text = Request.QueryString["RD"];
                lblWithheldAmount.Text = Request.QueryString["WAM"];
                lblRedisburseAmount.Text = Request.QueryString["CWAM"];
                lblApprovalLevelName.Text = Request.QueryString["LN"];

                GetApprovalHistory();
            }
        }
    }

    private void GetApprovalHistory()
    {
        List<ApprovalHistory> approvalHistory = RedisburseApprovalProcessDAL.GetRedisburseApprovalHistory(Id);
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
        //DisburseApprovalProcessEnt cap = new DisburseApprovalProcessEnt() { Id = Id, report_cycle_id = ReportCycleId, reportname = lblReportName.Text, report_duration = lblReportDuration.Text, flow_id = FlowId, level_id = LevelId, level_name = lblApprovalLevelName.Text, orderid = OrderId, claim_amt = lblClaimAmount.Text, disburse_amt = this.lblDisburseAmount.Text };
       // return DisburseApprovalProcessDAL.UpdateDisAppStatus(cap, IsAcept == true ? (Int16)1 : (Int16)2, this.txtComments.Text ?? String.Empty, LoginInfo.Current.UserId, LoginInfo.Current.UserName);
        return 1;
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