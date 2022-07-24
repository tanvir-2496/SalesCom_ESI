using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupApprovalLevelAdd20 : System.Web.UI.Page
{
    protected string editMode
    {
        get
        {
            return ViewState["editMode"].ToString();
        }
        set
        {
            ViewState["editMode"] = value;
        }
    }
    protected int Id
    {
        get
        {
            return (int)ViewState["Id"];
        }
        set
        {
            ViewState["Id"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ApprovalLevelAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            
            editMode = "add";
            Id = -1;

            Common.PopulateApprovalFlow(ddlApprovalFlowName, String.Empty);
            Common.AddSelectOne(ddlApprovalFlowName);
            Common.BindProcessStageOrder(ddlOrderID);

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ApprovalLevel20Ent approvalLevel = ApprovalLevel20DAL.GetApprovalLevelByFlowId(Id,0,0)[0];
                //UserInfoForView20 userInfo = LevelUser20DAL.GetUserInfoForView(Id, 0, 0, "")[0];
                //userID.Value = userInfo.UserId.ToString();
                ddlApprovalFlowName.SelectedValue = approvalLevel.ApprovalFlowID.ToString();
                ddlOrderID.SelectedValue = approvalLevel.OrderID.ToString();
                txtApprovalLevelName.Text= approvalLevel.ApprovalLevelName.ToString();
                btnSave.Visible = Permissions.ApprovalLevelAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Approval Level Information", this, lblMsg, txtApprovalLevelName.Text);
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
        txtApprovalLevelName.Text = String.Empty;
        ddlApprovalFlowName.SelectedIndex = -1;
        ddlOrderID.SelectedIndex = -1;
    }

    private int SaveData()
    {

        ApprovalLevel20Ent approvalLevel = new ApprovalLevel20Ent();
        approvalLevel.ApprovalLevelID = Id;
        approvalLevel.ApprovalLevelName = txtApprovalLevelName.Text;
        approvalLevel.ApprovalFlowID= int.Parse(ddlApprovalFlowName.SelectedValue);
        approvalLevel.OrderID = int.Parse(ddlOrderID.SelectedValue);

        if (editMode == "edit")
        {
            return ApprovalLevel20DAL.SaveItem(approvalLevel, "U",LoginInfo.Current.UserId);
        }
        else
        {
            return ApprovalLevel20DAL.SaveItem(approvalLevel, "I", LoginInfo.Current.UserId);
        }

    }




}