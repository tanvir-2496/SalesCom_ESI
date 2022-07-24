using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESI.DAL;
using ESI.Entity;
using System.Drawing;

public partial class TargetApprovalAct : System.Web.UI.Page
{

    protected Int32 Id
    {
        get { return (Int32)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected Int32 ReportCycleId
    {
        get { return (Int32)ViewState["RC"]; }
        set { ViewState["RC"] = value; }
    }

    protected Int32 OrderId
    {
        get { return (Int32)ViewState["OI"]; }
        set { ViewState["OI"] = value; }
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

                ReportCycleId = int.Parse(Request.QueryString["RC"]);

                LevelName = Request.QueryString["ALN"];

                OrderId = int.Parse(Request.QueryString["OI"]);

                GetApproveDRejectPermission(ReportCycleId, LevelName, OrderId);

                GetApprovalHistory();
            }
            
        }
        txtComments.Attributes.Add("maxlength", "300");
    }


    public void GetApproveDRejectPermission(int ReportCycleId, string level, int OrderId)
    {
        if (OrderId == 1)
        {
            //btnReject.Style["visibility"] = "hidden";

            int numPermission = ESI_PermissionDAL.TargetRejectPermission(ReportCycleId);

            if (numPermission > 0)
            {
                btnReject.Style["visibility"] = "hidden";
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

    private void ClearData()
    {
        Id = -1;
        txtComments.Text = String.Empty;
    }

    private int ApproveData(Boolean IsAcept)
    {
        string ext = String.Empty;
        byte[] srcontent = null;
        var filetype = "";

        

        if (ImageTypeFileUpLoad.HasFile)
        {
            ext = System.IO.Path.GetExtension(ImageTypeFileUpLoad.PostedFile.FileName);
            filetype = ext.Replace(".", String.Empty);
            srcontent = ImageTypeFileUpLoad.FileBytes;
        }
        else if (lblApprovalLevelName.Text == "KPI Uploader" || lblApprovalLevelName.Text == "Pending KPI Configure by Sales")
        {
            return -1;
        }
        return ESI_ReportApprovalDAL.KpiTargetApprovalAct(Id, txtComments.Text, LoginInfo.Current.UserId, LoginInfo.Current.UserName, filetype, srcontent);
    }

    private int RejectData()
    {
        return ESI_ReportApprovalDAL.TargetRejectionAct(Id, txtComments.Text, LoginInfo.Current.UserId, LoginInfo.Current.UserName);
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            int ErrorCode = ApproveData(true);
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
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {
            int ErrorCode = RejectData();
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
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }

}