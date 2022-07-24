using POS.BLL;
using POS.DAL;
using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;

public partial class SetupLevelUserAdd20 : System.Web.UI.Page
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
            if (!Permissions.LevelUserAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            editMode = "add";
            Id = -1;

            Common.PopulateApprovalFlow(ddlApprovalFlowName, String.Empty);
            Common.AddSelectOne(ddlApprovalFlowName);


            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                UserInfoForView20 userInfo = LevelUser20DAL.GetUserInfoForView(Id, 0, 0, "")[0];
                ddlApprovalFlowName.SelectedValue = userInfo.ApprovalFlowId.ToString();
                ddlApprovalFlowName_SelectedIndexChanged(null, null);
                ddlApprovalLevelName.SelectedValue = userInfo.ApprovalLevelId.ToString();
                userID.Value = userInfo.UserId.ToString();
                txtUser.Text = userInfo.LoginName;
                lbUserName.Text = userInfo.UserName;
                txtMobile.Text = userInfo.Mobile;
                txtEmail.Text = userInfo.Email;

                btnSave.Visible = Permissions.LevelUserAdd;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (userID.Value == "") return;
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Approval Level Information", this, lblMsg, txtUser.Text);
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
        ddlApprovalFlowName.SelectedIndex = -1;
        //ddlUserInfo.SelectedIndex = -1;
        txtUser.Text = "";
        ddlApprovalLevelName.SelectedIndex = -1;
    }

    private int SaveData()
    {
        LevelUser20Ent levelUser = new LevelUser20Ent();
        levelUser.LevelUserId = Id;
        levelUser.ApprovalLevelId = int.Parse(ddlApprovalLevelName.SelectedValue);
        levelUser.UserId = int.Parse(userID.Value);
        levelUser.Mobile = txtMobile.Text;
        levelUser.Email = txtEmail.Text;
        levelUser.FullName = lbUserName.Text;
        levelUser.LoginName = txtUser.Text;


        if (editMode == "edit")
        {
            return LevelUser20DAL.SaveItem(levelUser, "U",LoginInfo.Current.UserId);
        }
        else
        {
            return LevelUser20DAL.SaveItem(levelUser, "I", LoginInfo.Current.UserId);
        }

    }

    protected void ddlApprovalFlowName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.PopulateApprovalLevel(ddlApprovalLevelName, Convert.ToInt32(ddlApprovalFlowName.SelectedValue));
        Common.AddSelectOne(ddlApprovalLevelName);
    }
    protected void ddlApprovalLevelName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnUserSearch_Click(object sender, EventArgs e)
    {
        POS.DAL.UserInfo user = new POS.DAL.UserInfo();

        user.LOGINNAME = txtUser.Text;
        List<UserInfo> users = UserInfoBLL.UserInfoGetAll(user, "", 0, int.MaxValue);
        List<UserInfo> filteredUsers = users.FindAll(u => u.USERSTATUS.Trim().Equals("Y"));

        if (filteredUsers.Count > 0)
        {
            userID.Value = users[0].USERID.ToString();
            lbUserName.Text = users[0].USERNAME;
            lblFullName.Text = users[0].LOGINNAME;
            this.txtEmail.Text = users[0].EMAILADDR;
            this.txtMobile.Text = users[0].MOBILENO;

        }
        else
        {
            lbUserName.Text = "User not found.";
            userID.Value = "";
        }
    }
}