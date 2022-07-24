using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESI.DAL;
using ESI.Entity;
using System.Drawing;

public partial class TargetApprovalHistory : System.Web.UI.Page
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
            if (!Permissions.ESITargetApprovalAct)
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

                GetApprovalHistory();
            }
            
        }
    }

    private void GetApprovalHistory()
    {
        try
        {
            List<ApprovalHistoryEnt> approvalHistory = ESI_ReportApprovalDAL.GetApprovalHistory(Id, "Target");
            lv.DataSource = approvalHistory;
            lv.DataBind();
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }
}