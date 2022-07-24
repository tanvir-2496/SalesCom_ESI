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

    protected int SegmentId
    {
        get { return (int)ViewState["SegmetId"]; }
        set { ViewState["SegmetId"] = value; }
    }

    protected int EventId
    {
        get { return (int)ViewState["EventId"]; }
        set { ViewState["EventId"] = value; }
    }
    protected int MinP
    {
        get { return (int)ViewState["MinP"]; }
        set { ViewState["MinP"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.CommsiionReportSegmentsAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
            Common.PopulateEventType(ddlEventTypeId);
            Common.AddSelectOne(ddlEventTypeId);
            Common.PopulateSegment(ddlSegmentId);
            Common.AddSelectOne(ddlSegmentId);

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                SegmentId = int.Parse(Request["segId"]);
                EventId = int.Parse(Request["EvId"]);
                MinP = int.Parse(Request["minP"]);
                List<CommissionReportSegmentsEnt> commissionReportSegments = CommissionReportSegmentsDAL.GetItemList(Id, SegmentId, EventId, MinP);
                if (commissionReportSegments.Count > 0)
                {
                    ddlReportName.SelectedValue = commissionReportSegments[0].ReportId.ToString();
                    ddlSegmentId.SelectedValue = commissionReportSegments[0].SegmentId.ToString();
                    ddlEventTypeId.SelectedValue = commissionReportSegments[0].EventTypeId.ToString(); ;
                    txtMaxTarget.Text = commissionReportSegments[0].MaximumTargetPercentage.ToString();
                    txtMinTarget.Text = commissionReportSegments[0].MinimumTargetPercentage.ToString();
                    txtMinTargetAmount.Text = commissionReportSegments[0].MinimumTargetAmount.ToString();
                    txtMaxTargetAmount.Text = commissionReportSegments[0].MaximumTargetAmount.ToString();
                    txtAmount.Text = commissionReportSegments[0].Amount.ToString();
                    txtEventPercentage.Text = commissionReportSegments[0].EventPercentage.ToString();
                    txtSegmentAmount.Text = commissionReportSegments[0].SegmentAmount.ToString();
                    btnSave.Visible = Permissions.CommsiionReportSegmentsAdd;
                }

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
        MsgUtility.msg(editMode, ErrorCode, "Commsiion Report Segment", this, lblMsg, ddlReportName.Text);
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
        ddlReportName.SelectedIndex = ddlEventTypeId.SelectedIndex = ddlSegmentId.SelectedIndex = -1;
        txtMinTarget.Text = txtMaxTarget.Text = String.Empty;
    }

    private int SaveData()
    {

        CommissionReportSegmentsEnt commissionReportSegments = new CommissionReportSegmentsEnt();
        commissionReportSegments.ReportId = int.Parse(ddlReportName.SelectedValue);
        commissionReportSegments.SegmentId = int.Parse(ddlSegmentId.SelectedValue);
        commissionReportSegments.EventTypeId = int.Parse(ddlEventTypeId.SelectedValue);

        int maxTargetPer;
        int.TryParse(txtMaxTarget.Text, out maxTargetPer);
        commissionReportSegments.MaximumTargetPercentage = maxTargetPer;

        int minAmountPer;
        int.TryParse(txtMinTarget.Text, out minAmountPer);
        commissionReportSegments.MinimumTargetPercentage = minAmountPer;

        int minTarget;
        int.TryParse(txtMinTargetAmount.Text, out minTarget);
        commissionReportSegments.MinimumTargetAmount = minTarget;

        int maxTarget;
        int.TryParse(txtMaxTargetAmount.Text, out maxTarget);
        commissionReportSegments.MaximumTargetAmount = maxTarget;

        int eventPer;
        int.TryParse(txtEventPercentage.Text, out eventPer);
        commissionReportSegments.EventPercentage = eventPer;

        int segmentAmt;
        int.TryParse(txtSegmentAmount.Text, out segmentAmt);
        commissionReportSegments.SegmentAmount = segmentAmt;

        int amount;
        int.TryParse(txtAmount.Text, out amount);
        commissionReportSegments.Amount = amount;

        if (editMode == "edit")
        {
            return CommissionReportSegmentsDAL.SaveItem(commissionReportSegments, Id, SegmentId, EventId, MinP, "U");
        }
        else
        {
            return CommissionReportSegmentsDAL.SaveItem(commissionReportSegments, 0, 0, 0, 0, "I");
        }

    }


}