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
            if (!Permissions.ChannelAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            
            editMode = "add";
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ChannelEnt ChanneInfo = ChannelDAL.GetItemListForEdit(Id)[0];
                txtParentChannelID.Text = ChanneInfo.ParentChannelId.ToString();
                txtChannelTypeID.Text = ChanneInfo.ChannelTypeId.ToString();
                txtChannelName.Text = ChanneInfo.ChannelName.ToString();
                btnSave.Visible = Permissions.ChannelAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Channel Information", this, lblMsg, txtChannelName.Text);
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
        txtChannelName.Text = txtChannelTypeID.Text = txtParentChannelID.Text = String.Empty;

    }

    private int SaveData()
    {

        ChannelEnt ChannelInfo = new ChannelEnt();
        ChannelInfo.ChannelId = Id;
        ChannelInfo.ChannelTypeId = int.Parse(txtChannelTypeID.Text.Trim());
        ChannelInfo.ChannelName = txtChannelName.Text.Trim();
        ChannelInfo.ParentChannelId = int.Parse(txtParentChannelID.Text);

        if (editMode == "edit")
        {
            return ChannelDAL.SaveItem(ChannelInfo, "U");
        }
        else
        {
            return ChannelDAL.SaveItem(ChannelInfo, "I");
        }

    }
 

}