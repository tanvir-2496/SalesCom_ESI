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
            if (!Permissions.SegmentTypeAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            Common.PopulateChannelType(ddlChannelTypeName);
            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                SegmentTypeEntForView SegmentTypeInfo = SegmentTypeDAL.GetItemList(Id)[0];
                txtTypeName.Text = SegmentTypeInfo.TypeName;
                ddlChannelTypeName.SelectedValue = SegmentTypeInfo.ChannelTypeId.ToString();
                btnSave.Visible = Permissions.SegmentTypeAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Segment Type Information", this, lblMsg, txtTypeName.Text);
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
        txtTypeName.Text = String.Empty;
        ddlChannelTypeName.SelectedIndex = -1;
    }

    private int SaveData()
    {

        SegmentTypeEnt SegmentTypeypeInfo = new SegmentTypeEnt();
        SegmentTypeypeInfo.SegmentTypeId = Id;
        SegmentTypeypeInfo.TypeName = txtTypeName.Text.Trim();
        SegmentTypeypeInfo.ChannelTypeId = int.Parse(ddlChannelTypeName.SelectedValue);

        if (editMode == "edit")
        {
            return SegmentTypeDAL.SaveItem(SegmentTypeypeInfo, "U");
        }
        else
        {
            return SegmentTypeDAL.SaveItem(SegmentTypeypeInfo, "I");
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Id < 1 || ddlChannelTypeName.SelectedIndex < 1)
            return;
        SegmentTypeEnt obj = new SegmentTypeEnt();
        obj.SegmentTypeId = Id;
        obj.TypeName = txtTypeName.Text;
        obj.ChannelTypeId = int.Parse(ddlChannelTypeName.SelectedValue);
        //   obj.EventValidationID = -1;
        int ErrorCode = SegmentTypeDAL.SaveItem(obj, "I");
        if (ErrorCode <= -1)
            lblMsg.Text = "Data Can not Add !!";
        else
        {
            lblMsg.Text = "Data Add Successful!!";
        }

    }
   
}