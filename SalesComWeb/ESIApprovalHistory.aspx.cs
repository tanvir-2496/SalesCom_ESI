using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESI.DAL;
using ESI.Entity;

public partial class ESIApprovalHistory : System.Web.UI.Page
{
    protected Int32 Id
    {
        get { return (Int32)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected String LevelName
    {
        get { return Convert.ToString(ViewState["ALN"]); }
        set { ViewState["ALN"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ESIKpiApprovalAct)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                lblReportName.Text = Request.QueryString["RN"];
                lblApprovalLevelName.Text = Request.QueryString["ALN"];

                LevelName = Request.QueryString["ALN"];

                GetApproveDRejectPermission(LevelName);

                GetApprovalHistory();
            }

        }
    }

    public void GetApproveDRejectPermission(string level)
    {
        if(level.Contains("Uploader"))
        {
            //btnReject.Style["visibility"] = "hidden";
            //btnApprove.Text = "Submit";
        }
    }

    private void GetApprovalHistory()
    { 
        //ApprovalHistoryEnt
        List<ApprovalHistoryEnt> approvalHistory = ESI_ReportApprovalDAL.GetDetailApprovalHistory(Id);
        lv.DataSource = approvalHistory;
        lv.DataBind();
    }

    private void ClearData()
    {
        //Id = -1;
        //txtComments.Text = String.Empty;
        //string script = "$(document).ready(function() { tb_remove();});";
        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", script, true);
    }
}