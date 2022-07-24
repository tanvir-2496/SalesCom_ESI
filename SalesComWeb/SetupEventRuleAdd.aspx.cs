using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupEventRuleAdd : System.Web.UI.Page
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
            if (!Permissions.EventRuleAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
            Common.PopulateAmountType(ddlAmountTypeID);
            Common.AddSelectOne(ddlAmountTypeID);
            Common.PopulateSegment(ddlSegmentID);
            Common.AddSelectOne(ddlSegmentID);
            Common.PopulateValidationRule(ddlValidationRuleID);
            Common.AddSelectOne(ddlValidationRuleID);
            Common.PopulateCommissionType(ddlCommissionType);
            Common.AddSelectOne(ddlCommissionType);

            Common.PopulateRuleGroup(ddlRuleGroup);
            Common.AddSelectOne(ddlRuleGroup);

            Common.PopulateEvent(ddlEventName);
            Common.AddSelectOne(ddlEventName);
            
            //{
            //    Id = 2473;
            //    EventRuleEnt EventInfo = EventRuleDAL.GetItemList(Id, 0, 0)[0];
            //    ddlEventName.SelectedValue = EventInfo.EventID.ToString();
            //    ddlSegmentID.SelectedValue = EventInfo.SegmentID.ToString();
            //    txtMinAmount.Text = EventInfo.MinAmount.ToString();
            //    txtMaxAmount.Text = EventInfo.MaxAmount.ToString();
            //    ddlAmountTypeID.SelectedValue = EventInfo.AmountTypeID.ToString();
            //    ddlCommissionType.SelectedValue = EventInfo.CommissionType;
            //    txtCommissionValue.Text = EventInfo.CommissionValue.ToString();
            //    txtMaxCommissionPerevent.Text = EventInfo.MaxCommissionPerevent.ToString();
            //    ddlValidationRuleID.SelectedValue = EventInfo.ValidationRuleID.ToString();
            //    ddlReportName.SelectedValue = EventInfo.Reportid.ToString();
            //    ddlRuleGroup.SelectedValue = EventInfo.RuleGroupID.ToString();
            //    txtEventRuleName.Text = EventInfo.EventRuleName;
            //}

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                EventRuleEnt EventInfo = EventRuleDAL.GetItemList(Id, 0, 0)[0];
                ddlEventName.SelectedValue = EventInfo.EventID.ToString();
                ddlSegmentID.SelectedValue = EventInfo.SegmentID.ToString();
                txtMinAmount.Text = EventInfo.MinAmount.ToString();
                txtMaxAmount.Text = EventInfo.MaxAmount.ToString();
                ddlAmountTypeID.SelectedValue = EventInfo.AmountTypeID.ToString();
                ddlCommissionType.SelectedValue = EventInfo.CommissionType;
                txtCommissionValue.Text = EventInfo.CommissionValue.ToString();
                txtMaxCommissionPerevent.Text = EventInfo.MaxCommissionPerevent.ToString();
                ddlValidationRuleID.SelectedValue = EventInfo.ValidationRuleID.ToString();
                ddlReportName.SelectedValue = EventInfo.Reportid.ToString();
                ddlRuleGroup.SelectedValue = EventInfo.RuleGroupID.ToString();
                txtEventRuleName.Text = EventInfo.EventRuleName;
                btnSave.Visible = Permissions.EventRuleAdd;

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
        MsgUtility.msg(editMode, ErrorCode, "Event Information", this, lblMsg, "");
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
        ddlEventName.SelectedIndex = -1;
        ddlSegmentID.SelectedIndex = -1;
        txtMinAmount.Text = "";
        txtMaxAmount.Text = "";
        ddlAmountTypeID.SelectedIndex = -1;
        ddlCommissionType.SelectedIndex = -1;
        txtCommissionValue.Text = "";
        txtMaxCommissionPerevent.Text = "";
        ddlValidationRuleID.SelectedIndex = -1;
        //  txtEventName.Text =  txtEffectiveDate.Text = txtExpiryDate.Text = txtFrequency.Text = String.Empty;
        // ddlEventTypeID.SelectedIndex = -1;
    }

    private int SaveData()
    {
        EventRule2 EventInfo = new EventRule2();
        EventInfo.EventRuleID = Id;
        EventInfo.EventID = int.Parse(ddlEventName.SelectedValue);
        EventInfo.SegmentID = int.Parse(ddlSegmentID.SelectedValue);


        EventInfo.MinAmount = decimal.Parse(txtMinAmount.Text);
        EventInfo.MaxAmount = decimal.Parse(txtMaxAmount.Text);

        EventInfo.AmountTypeID = int.Parse(ddlAmountTypeID.SelectedValue);


        EventInfo.CommissionType = ddlCommissionType.SelectedValue;
        EventInfo.CommissionValue = decimal.Parse(txtCommissionValue.Text);
        EventInfo.MaxCommissionPerevent = decimal.Parse(txtMaxCommissionPerevent.Text);
        EventInfo.ValidationRuleID = int.Parse(ddlValidationRuleID.SelectedValue);
        EventInfo.RuleGroupID = int.Parse(ddlRuleGroup.SelectedValue);
        EventInfo.EventRuleName = txtEventRuleName.Text;
        if (editMode == "edit")
        {
            EventInfo.UpdateBy = LoginInfo.Current.UserId;
            return EventRuleDAL.SaveItem(EventInfo, "U");
        }
        else
        {
            EventInfo.CreateBy = LoginInfo.Current.UserId;
            return EventRuleDAL.SaveItem(EventInfo, "I");
        }

    }



    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex > 0)
        {
            Common.PopulateEventByReportId(ddlEventName, int.Parse(ddlReportName.SelectedValue));
            Common.AddSelectOne(ddlEventName);
        }
        else
        {
            ddlEventName.Items.Clear();
        }
    }
}