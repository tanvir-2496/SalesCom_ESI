using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupEventAdd : System.Web.UI.Page
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
            Common.PopulateProductChannel(ddlProductChannelName);
            Common.AddSelectOne(ddlProductChannelName);
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                EventEnt EventInfo = EventDAL.GetItemList(Id)[0];
                txtEventName.Text = EventInfo.EventName;
                ddlEventTypeID.SelectedValue = EventInfo.EventTypeID.ToString();
                ddlChannelType.SelectedValue = EventInfo.ChannelTypeID.ToString();
                txtEffectiveDate.Text = EventInfo.EffectiveDate.ToString("dd-MM-yyyy");
                txtExpiryDate.Text = EventInfo.ExpiryDate.ToString("dd-MM-yyyy");
                ddlProductChannelName.SelectedValue = EventInfo.ProductChannelId.ToString();
                ddlReportName.SelectedValue = EventInfo.ReportId.ToString();
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
        Event2 EventInfo = new Event2();
        EventInfo.EventID = Id;
        EventInfo.EventName = txtEventName.Text.Trim();
        EventInfo.EventTypeID = int.Parse(ddlEventTypeID.SelectedValue);
        EventInfo.EffectiveDate = DateTime.Parse(txtEffectiveDate.Text);
        DateTime dt;
        DateTime.TryParse(txtExpiryDate.Text, out dt);
        EventInfo.ExpiryDate = dt;
        //   EventInfo.Frequency = int.Parse(txtFrequency.Text);
        EventInfo.ChannelTypeID = int.Parse(ddlChannelType.SelectedValue);
        EventInfo.ProductChannelId = int.Parse(ddlProductChannelName.SelectedValue);
        EventInfo.ReportId = int.Parse(ddlReportName.SelectedValue);

        if (editMode == "edit")
        {
            EventInfo.UpdateBy = LoginInfo.Current.UserId;
            return EventDAL.SaveItem(EventInfo, "U");
        }
        else
        {
            EventInfo.CreateBy = LoginInfo.Current.UserId;
            return EventDAL.SaveItem(EventInfo, "I");
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