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
            if (!Permissions.EventTypeAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                EventTypeEnt EventTypeInfo = EventTypeDAL.GetItemList(Id)[0];
                txtEventType.Text = EventTypeInfo.EventType;
                btnSave.Visible = Permissions.EventTypeAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Event Type Information", this, lblMsg, txtEventType.Text);
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
        txtEventType.Text = String.Empty;
    }

    private int SaveData()
    {

        EventType2 EventTypeInfo = new EventType2();
        EventTypeInfo.EventTypeId = Id;
        EventTypeInfo.EventType = txtEventType.Text.Trim();



        if (editMode == "edit")
        {
            EventTypeInfo.UpdateBy = LoginInfo.Current.UserId;
            return EventTypeDAL.SaveItem(EventTypeInfo, "U");
        }
        else
        {
            EventTypeInfo.CreateBy = LoginInfo.Current.UserId;
            return EventTypeDAL.SaveItem(EventTypeInfo, "I");
        }

    }


}