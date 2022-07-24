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
            if (!Permissions.SegmentAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            
            editMode = "add";
            Id = -1;

            Common.PopulateSegmentType(ddlSegmentType);
          

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                SegmentTypeSegmentEnt SegmentInfo = SegmentDAL.SetSegmentByID(Id)[0];
                txtSegmentName.Text = SegmentInfo.SegmentName;
                ddlSegmentType.SelectedValue = SegmentInfo.SegmentTypeID.ToString();
               btnSave.Visible = Permissions.SegmentAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Segment Type Information", this, lblMsg, txtSegmentName.Text);
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
        txtSegmentName.Text = String.Empty;
        ddlSegmentType.SelectedIndex = -1;
    }

    private int SaveData()
    {

        SegmentEnt SegmentInfo = new SegmentEnt();
        SegmentInfo.SegmentID = Id;
        SegmentInfo.SegmentName = txtSegmentName.Text.Trim();
        SegmentInfo.SegmentTypeID = int.Parse(ddlSegmentType.SelectedValue);

        if (editMode == "edit")
        {
            return SegmentDAL.SaveItem(SegmentInfo, "U");
        }
        else
        {
            return SegmentDAL.SaveItem(SegmentInfo, "I");
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Id < 1 || ddlSegmentType.SelectedIndex < 1)
            return;
        SegmentEnt obj = new SegmentEnt();
        obj.SegmentID = Id;
        obj.SegmentName = txtSegmentName.Text;
        obj.SegmentTypeID = int.Parse(ddlSegmentType.SelectedValue);
        int ErrorCode = SegmentDAL.SaveItem(obj, "I");
        if (ErrorCode <= -1)
            lblMsg.Text = "Data Can not Add !!";
        else
        {
            lblMsg.Text = "Data Add Successful!!";
        }

    }
   
}