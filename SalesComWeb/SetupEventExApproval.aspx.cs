using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class PendingApprovalView : System.Web.UI.Page
{
    protected int Id
    {
        get { return (int)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected string LevelName
    {
        get { return (String)ViewState["LN"]; }
        set { ViewState["LN"] = value; }
    }

    protected string ApprovalflowName
    {
        get { return (String)ViewState["AN"]; }
        set { ViewState["AN"] = value; }
    }
    protected int LevelId
    {
        get { return (int)ViewState["LI"]; }
        set { ViewState["LI"] = value; }
    }
    protected int ApprovalflowId
    {
        get { return (int)ViewState["AI"]; }
        set { ViewState["AI"] = value; }
    }

    protected int OrderId
    {
        get { return (int)ViewState["OID"]; }
        set { ViewState["OID"] = value; }
    }

    protected string ReportName
    {
        get { return (string)ViewState["ReportName"]; }
        set { ViewState["ReportName"] = value; }
    }
    protected string CycleDesc
    {
        get { return (string)ViewState["CycleDesc"]; }
        set { ViewState["CycleDesc"] = value; }
    }

    protected string CycleId
    {
        get { return (string)ViewState["CyId"]; }
        set { ViewState["CyId"] = value; }
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

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                LevelId = int.Parse(Request.QueryString["LI"]);
                LevelName = Request.QueryString["LN"];
                ApprovalflowId = int.Parse(Request.QueryString["AI"]);
                ApprovalflowName = Request.QueryString["AN"];
                OrderId = int.Parse(Request.QueryString["OID"]);
                ReportName = Request.QueryString["ReN"];
                CycleId = Request.QueryString["CyId"];
                lblReportName.Text = ReportName;
                CycleDesc = Request.QueryString["CyD"];
                lblCycle.Text = CycleDesc;
                lblCommissionAmt.Text = Request.QueryString["CAmt"];
                lblWithheldAmount.Text = Request.QueryString["CAmtW"];
                int camount = 0;
                int wamount = 0;
                int.TryParse(lblCommissionAmt.Text, out camount);
                int.TryParse(lblWithheldAmount.Text, out wamount);
                lblPaybaleAmout.Text = (camount - wamount).ToString();
                this.lblApprovalLevelName.Text = LevelName;

                List<CommentsCycleEnt> temp = PendingApprovalWithStatusDAL.GetPreviousComment(ApprovalflowId, 0);

                if (temp.Count > 0) this.txtPreviousComments.Text = temp.Count > 0 ? temp[0].Comments : String.Empty;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }

    private void ClearData()
    {
        Id = -1;
        txtComments.Text = txtPreviousComments.Text = String.Empty;
        string script = "$(document).ready(function() { tb_remove();});";
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", script, true);
    }

    private int SaveData(Boolean IsAcept)
    {
        PendingApprovalWithStatusAndCommentEnt pendingApprovalWithComments = new PendingApprovalWithStatusAndCommentEnt();
        pendingApprovalWithComments.PendingApprovalId = Id;
        pendingApprovalWithComments.OrderId = OrderId + 1;
        pendingApprovalWithComments.LevelId = LevelId;
        pendingApprovalWithComments.CycleId = int.Parse(CycleId);
        pendingApprovalWithComments.ApprovalFlowId = ApprovalflowId;
        pendingApprovalWithComments.Comments = txtComments.Text;
        pendingApprovalWithComments.Status = IsAcept == true ? 1 : 2;
        return PendingApprovalWithStatusDAL.UpdateStatusWithComments(pendingApprovalWithComments, LoginInfo.Current.UserName, double.Parse(this.lblPaybaleAmout.Text), "U");
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData(true);
        ScriptManager.RegisterStartupScript(this, typeof(string), "Successful", "alert('Information updated successfully.');", true);

        if (ErrorCode >= 0)
        {
            ClearData();
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
        ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "parent.tb_remove();", true);
    }
}