using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SetupLevelUser20 : System.Web.UI.Page
{

    protected bool isFilterByUser
    {
        get { return (bool)ViewState["isFilterByUser"]; }
        set { ViewState["isFilterByUser"] = value; }
    }

    protected void pager_PreRender(object sender, EventArgs e)
    {
        DindDataToGrid(isFilterByUser);
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
            if (!Permissions.LevelUserView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateApprovalFlow(ddlApprovalName, String.Empty);
            Common.AddSelectAll(ddlApprovalName);
            Common.AddSelectAll(ddlApprovalLevelName);
            isFilterByUser = false;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                UserInfoForView20 userInfo = LevelUser20DAL.GetUserInfoForView(Id, 0, 0, "")[0];

                ddlApprovalLevelName.SelectedValue = userInfo.ApprovalLevelId.ToString();
                
                              
            }
        }

        this.lblError.Text = String.Empty;
    }

    private void BindData(DataGetType dataGetType)
    {
        List<UserInfoForView20> list = new List<UserInfoForView20>();

        if (dataGetType == DataGetType.AllFlow)
        {
            list = LevelUser20DAL.GetUserInfoForView(0, 0, 0, null);
        }
        else if (dataGetType == DataGetType.Flow)
        {
            list = LevelUser20DAL.GetUserInfoForView(0, Convert.ToInt32(ddlApprovalName.SelectedValue), 0, null);
        }
        else if (dataGetType == DataGetType.FlowLevel)
        {
            list = LevelUser20DAL.GetUserInfoForView(0, Convert.ToInt32(ddlApprovalName.SelectedValue), Convert.ToInt32(ddlApprovalLevelName.SelectedValue), null);
        }
        else if (dataGetType == DataGetType.User)
        {
            list = LevelUser20DAL.GetUserInfoForView(0, 0, 0, txtUser.Text);
        }

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void ddlApprobalName_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlApprovalName.SelectedIndex > 0)
        {
            Common.PopulateApprovalLevel(ddlApprovalLevelName, int.Parse(ddlApprovalName.SelectedValue));
            Common.AddSelectAll(ddlApprovalLevelName);
        }
        else
        {
            this.ddlApprovalLevelName.Items.Clear();
            Common.AddSelectAll(ddlApprovalLevelName);
        }
        isFilterByUser = false;
        pager.SetPageProperties(0, pager.MaximumRows, false);
        DindDataToGrid(isFilterByUser);
    }

    protected void ddlApprovalLevelName_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.SetPageProperties(0, pager.MaximumRows, false);
        isFilterByUser = false;
        DindDataToGrid(isFilterByUser);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        DindDataToGrid(isFilterByUser);
    }
        
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        Button myButton = (Button)sender;
        int i = Convert.ToInt32(myButton.CommandArgument.ToString());
       
        LevelUser20DAL.DelteItem(i, LoginInfo.Current.UserId);
        //LevelUser20DAL.DelteItem(i);
        pager.SetPageProperties(0, pager.MaximumRows, false);
        DindDataToGrid(isFilterByUser);
    }

    protected void btnFilterByUser_Click(object sender, EventArgs e)
    {
        isFilterByUser = true;
        this.ddlApprovalName.SelectedIndex = 0;
        this.ddlApprovalLevelName.Items.Clear();
        Common.AddSelectAll(ddlApprovalLevelName);
        pager.SetPageProperties(0, pager.MaximumRows, false);
        DindDataToGrid(isFilterByUser);
    }
    
    protected void DindDataToGrid(bool isFilterByUser)
    {
        if (isFilterByUser == false)
        {
            this.txtUser.Text = String.Empty;
            if (this.ddlApprovalName.SelectedIndex > 0 && this.ddlApprovalLevelName.SelectedIndex > 0)
            {
                BindData(DataGetType.FlowLevel);
            }
            else if (this.ddlApprovalName.SelectedIndex > 0)
            {
                BindData(DataGetType.Flow);
            }
            else if (this.ddlApprovalName.SelectedIndex == 0)
            {
                BindData(DataGetType.AllFlow);
            }
        }
        else
        {
            if (String.IsNullOrEmpty(txtUser.Text.Trim()) == false)
            {
                BindData(DataGetType.User);
            }
            else
            {
                BindData(DataGetType.Empty);
                this.lblError.Text = "User name is required!";
            }
        }
    }

    enum DataGetType
    {
        AllFlow,
        Flow,
        User,
        FlowLevel,
        Empty
    };


}