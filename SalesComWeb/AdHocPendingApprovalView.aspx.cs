using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class PendingApprovalView : System.Web.UI.Page
{

    protected Int32 Id
    {
        get { return (Int32)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
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
            if (!Permissions.AdhocPendingApprovalViewView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                FlowId = Int16.Parse(Request.QueryString["FID"]);
                LevelId = Int16.Parse(Request.QueryString["LID"]);
                OrderId = Int16.Parse(Request.QueryString["OID"]);
                lblReportName.Text = Request.QueryString["RN"];
                lblReportDate.Text = Request.QueryString["RD"];
                lblReportGenerationDate.Text = Request.QueryString["RGD"];
                lblCommissionAmt.Text = Request.QueryString["COM"];
                lblApprovalLevelName.Text = Request.QueryString["LN"];

                GetApprovalHistory();
            }
        }
    }

    private void GetApprovalHistory()
    {
        List<ApprovalHistory> approvalHistory = AdHocPendingApprovalDAL.GetApprovalHistory(Id);
        lv.DataSource = approvalHistory;
        lv.DataBind();
    }

    private void ClearData()
    {
        Id = -1;
        txtComments.Text = String.Empty;
        string script = "$(document).ready(function() { tb_remove();});";
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", script, true);
    }

    private int SaveData(Boolean IsAcept)
    {
        ApprovalDetail ad = new ApprovalDetail() { Id = Id, ReportName = lblReportName.Text, ReportDate = lblReportDate.Text, ReportGenDate = lblReportGenerationDate.Text, Commission = lblCommissionAmt.Text, FlowId = FlowId, LevelId = LevelId, LevelName = lblApprovalLevelName.Text, Order = OrderId, Comment = txtComments.Text ?? String.Empty, Status = IsAcept == true ? (Int16)1 : (Int16)2, UserId = LoginInfo.Current.UserId, UserName = LoginInfo.Current.UserName };
        return AdHocPendingApprovalDAL.UpdateAdHocPendingStatus(ad);
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