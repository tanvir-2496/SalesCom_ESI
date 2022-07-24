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
            if (!Permissions.ChannelTypeAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            
            editMode = "add";
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ChannelTypeEnt ChannelTypeInfo = ChannelTypeDAL.GetItemList(Id)[0];
                txtChannelType.Text = ChannelTypeInfo.ChannelType;
                btnSave.Visible = Permissions.ChannelTypeAdd;
            }
            else

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Channel Type Information", this, lblMsg, txtChannelType.Text);
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
        txtChannelType.Text = String.Empty;
    }

    private int SaveData()
    {

        ChannelTypeEnt ChannelTypeInfo = new ChannelTypeEnt();
        ChannelTypeInfo.ChannelTypeId = Id;
        ChannelTypeInfo.ChannelType = txtChannelType.Text.Trim();

        if (editMode == "edit")
        {
            return ChannelTypeDAL.SaveItem(ChannelTypeInfo, "U");
        }
        else
        {
            return ChannelTypeDAL.SaveItem(ChannelTypeInfo, "I");
        }

    }


}