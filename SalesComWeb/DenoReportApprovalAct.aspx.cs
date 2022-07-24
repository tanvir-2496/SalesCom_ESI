using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesCom.Entity;
using SalesCom.DAL;

public partial class DenoReportApprovalAct : System.Web.UI.Page
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

    protected Int16 DenoTypeId
    {
        get { return (Int16)ViewState["DenoTypeId"]; }
        set { ViewState["DenoTypeId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.CampaignDenoApproveAct)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                FlowId = Int16.Parse(Request.QueryString["AF"]);
                LevelId = Int16.Parse(Request.QueryString["AL"]);
                DenoTypeId = Int16.Parse(Request.QueryString["DT"]);
                OrderId = Int16.Parse(Request.QueryString["OI"]);
                lblReportName.Text = Request.QueryString["RN"];
                lblApprovalLevelName.Text = Request.QueryString["ALN"];

                GetApprovalHistory();
            }
        }
    }

    private void GetApprovalHistory()
    {
        List<ApprovalHistory> approvalHistory = ReportApprovalDAL.GetApprovalHistory(Id);
        lv.DataSource = approvalHistory;
        lv.DataBind();
    }

    private void ClearData()
    {
        Id = -1;
        txtComments.Text = String.Empty;
        //string script = "$(document).ready(function() { tb_remove();});";
        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", script, true);
    }

    private int SaveData(Boolean IsAcept)
    {
        DenoReportApprovalEnt ad = new DenoReportApprovalEnt() { id = Id, approval_flow_id=FlowId, report_name = lblReportName.Text, deno_type_id=DenoTypeId, approval_level_id = LevelId, approvallevelname = lblApprovalLevelName.Text, orderid = OrderId, comments = txtComments.Text ?? String.Empty, status = IsAcept == true ? (Int16)1 : (Int16)2 };
        return DenoReportApprovalDAL.ReportApprovalAct(ad, LoginInfo.Current.UserId, LoginInfo.Current.UserName);
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