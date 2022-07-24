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
            if (!Permissions.EventAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            editMode = "add";
            Id = -1;

            Common.PopulateEventType(ddlEventTypeID);
            Common.AddSelectOne(ddlEventTypeID);
            Common.PopulateChannelType(ddlChannelType);
            Common.AddSelectOne(ddlChannelType);
            //Common.PopulateApprovalFlow(ddlApprovalFlowName);
            //Common.AddSelectOne(ddlApprovalFlowName);
            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                EventExEnt EventExInfo = EventExDAL.GetItemList(Id, 0, String.Empty, 0)[0];
                txtEventName.Text = EventExInfo.EventName;
                ddlEventTypeID.SelectedValue = EventExInfo.EventTypeId.ToString();
                ddlChannelType.SelectedValue = EventExInfo.ChannelTypeId.ToString();

                txtEffectiveDate.Text = EventExInfo.EffectiveDate.ToString("dd-MM-yyyy");
                txtExpiryDate.Text = EventExInfo.ExpiryDate.ToString("dd-MM-yyyy");
                //ddlApprovalFlowName.SelectedValue = EventExInfo.ApprovalFlowId.ToString();
                btnSave.Visible = Permissions.EventAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Event Information", this, lblMsg, txtEventName.Text);
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
        txtEventName.Text = txtEffectiveDate.Text = txtExpiryDate.Text = String.Empty;
        ddlEventTypeID.SelectedIndex = -1;
    }

    private int SaveData()
    {
        EventExEnt EventExInfo = new EventExEnt();
        EventExInfo.EventId = Id;
        EventExInfo.EventName = txtEventName.Text.Trim();
        EventExInfo.EventTypeId = int.Parse(ddlEventTypeID.SelectedValue);
        EventExInfo.EffectiveDate = DateTime.Parse(txtEffectiveDate.Text);
        DateTime dt;
        DateTime.TryParse(txtExpiryDate.Text, out dt);
        EventExInfo.ExpiryDate = dt;
        //EventExInfo.ApprovalFlowId = int.Parse(ddlApprovalFlowName.SelectedValue);
        //   EventInfo.Frequency = int.Parse(txtFrequency.Text);

        EventExInfo.ChannelTypeId = int.Parse(ddlChannelType.SelectedValue);

        if (editMode == "edit")
        {
            return EventExDAL.SaveItem(EventExInfo, "U");
        }
        else
        {
            return EventExDAL.SaveItem(EventExInfo, "I");
        }

    }


    protected void lvEOMaster_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (string.Equals(e.CommandName, "Del"))
        {
            int i = -1;
            string[] arguments = e.CommandArgument.ToString().Split('|');


            if (Id > -1)
            {
                EventValidationEnt obj = new EventValidationEnt();
                obj.EventValidationID = int.Parse(arguments[0]);
                i = EventValidationDAL.SaveItem(obj, "D");

                if (i <= -1)
                    lblMsg.Text = "Data Can not Delete !!";
                else
                {
                    lblMsg.Text = "Data Delete Successful!!";
                }
            }
            else
                lblMsg.Text = "Data Can not Delete !!";

        }
    }

}