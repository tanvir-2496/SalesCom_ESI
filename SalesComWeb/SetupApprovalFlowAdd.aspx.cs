using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupActivityAdd : System.Web.UI.Page
{
    protected string editMode
    {
        get { return ViewState["editMode"].ToString(); }
        set { ViewState["editMode"] = value; }
    }
    protected int Id
    {
        get { return (int)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ApprovalFlowAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;
            ddlFlowType.DataSource = System.Configuration.ConfigurationManager.AppSettings["ApprovalType"].ToString().Split(',').ToList();
            ddlFlowType.DataBind();

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ApprovalFlowEnt approvalFlow = ApprovalFlowDAL.GetApprovalFlowList(Id, String.Empty)[0];
                txtApprovalName.Text = approvalFlow.ApprovalName;
                ddlFlowType.SelectedValue = approvalFlow.ApprovalType;
                btnSave.Visible = Permissions.ApprovalFlowAdd;
            }
            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Approval Flow Information", this, lblMsg, txtApprovalName.Text);
        if (editMode == "add")
        {
            if (ErrorCode >= 0)
            {
                ClearData();
            }
        }
    }

    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        txtApprovalName.Text = String.Empty;
    }

    private int SaveData()
    {

        ApprovalFlowEnt approvalFlowInfo = new ApprovalFlowEnt();
        approvalFlowInfo.ApprovalFlowID = Id;
        approvalFlowInfo.ApprovalName = txtApprovalName.Text.Trim();
        approvalFlowInfo.ApprovalType = ddlFlowType.SelectedValue;

        if (editMode == "edit")
        {
            return ApprovalFlowDAL.SaveItem(approvalFlowInfo, "U",LoginInfo.Current.UserId);
        }
        else
        {
            return ApprovalFlowDAL.SaveItem(approvalFlowInfo, "I",LoginInfo.Current.UserId);
        }

    }


}