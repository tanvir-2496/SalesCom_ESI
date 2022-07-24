using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupEventRule : System.Web.UI.Page
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

    protected Int32 LevelId
    {
        get { return (Int32)ViewState["LevelId"]; }
        set { ViewState["LevelId"] = value; }
    }

    protected Int16 OrderId
    {
        get { return (Int16)ViewState["OrderId"]; }
        set { ViewState["OrderId"] = value; }
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


            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                List<EventRuleExEnt> EventInfo = EventRuleExDAL.GetItemList(Id, 0, 0);
                if (EventInfo.Count > 0)
                {
                    LevelId = EventInfo[0].ApprovalLevelId;

                    lblEventRuleName.Text = EventInfo[0].EventRuleName;
                    hfEventRuleName.Value = EventInfo[0].EventRuleID.ToString();
                    lblEventName.Text = EventInfo[0].EventName;
                    lblReportName.Text = EventInfo[0].ReportName;
                    lblSegment.Text = EventInfo[0].SegmentName;
                    lblMinAmount.Text = EventInfo[0].MinAmount.ToString();
                    lblMaxAmount.Text = EventInfo[0].MaxAmount.ToString();
                    lblAmountType.Text = EventInfo[0].AmountTypeName;
                    lblCommissionType.Text = EventInfo[0].CommissionType;
                    lblCommissionValue.Text = EventInfo[0].CommissionValue.ToString();
                    lblMaxComPercentage.Text = EventInfo[0].MaxCommissionPerevent.ToString();
                    lblRuleGroup.Text = EventInfo[0].RuleGroupName;
                    lblValidationRule.Text = EventInfo[0].ValidationName;
                    lblApprovalChain.Text = EventInfo[0].ApprovalLevelName;
                    hfFlowId.Value = EventInfo[0].ApprovalFlowId.ToString();
                    lblCurrentLevel.Text = EventInfo[0].CurrentLevel.ToString();
                    hfLevelId.Value = EventInfo[0].ApprovalLevelId.ToString();
                    OrderId = EventInfo[0].OrderId;

                    lblComments.Text = EventInfo[0].Comments;

                    if (EventInfo[0].Status == 2)
                    {
                        List<EventRuleExEnt> EventInfoLog = EventRuleExDAL.GetItemListFromLog(EventInfo[0].LastEventRuleExLogId);
                        if (EventInfoLog.Count > 0)
                        {
                            ChangedData(lblEventRuleAltered, EventInfo[0].EventRuleName, EventInfoLog[0].EventRuleName);
                            ChangedData(lblEventRuleAltered, EventInfo[0].EventRuleName, EventInfoLog[0].EventRuleName);
                            //ChangedData(lblEventNameAltered, EventInfo[0].EventName, EventInfoLog[0].EventName);
                            ChangedData(lblSegmentAltered, EventInfo[0].SegmentName, EventInfoLog[0].SegmentName);
                            ChangedData(lblMinAmountAltered, EventInfo[0].MinAmount, EventInfoLog[0].MinAmount);
                            ChangedData(lblMaxAmountAltered, EventInfo[0].MaxAmount, EventInfoLog[0].MaxAmount);
                            ChangedData(lblAmountTypeAltered, EventInfo[0].AmountTypeName, EventInfoLog[0].AmountTypeName);
                            ChangedData(lblCommissionTypeAltered, EventInfo[0].CommissionType, EventInfoLog[0].CommissionType);
                            ChangedData(lblCommissionValueAltered, EventInfo[0].CommissionValue, EventInfoLog[0].CommissionValue);
                            ChangedData(lblMaxComPercentageAltered, EventInfo[0].MaxCommissionPerevent, EventInfoLog[0].MaxCommissionPerevent); ;
                            ChangedData(lblRuleGroupAltered, EventInfo[0].RuleGroupName, EventInfoLog[0].RuleGroupName);
                            ChangedData(lblValidationRuleAltered, EventInfo[0].ValidationName, EventInfoLog[0].ValidationName);
                            ChangedData(lblApprovalChainAltered, EventInfo[0].ApprovalLevelName, EventInfoLog[0].ApprovalLevelName);
                            ChangedData(lblCurrentLevelAltered, EventInfo[0].CurrentLevel, EventInfoLog[0].CurrentLevel);
                            ChangedData(lblCommentsAltered, EventInfo[0].Comments, EventInfoLog[0].Comments);
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    private void ChangedData<T>(Label label, T Old, T Altered)
    {
        bool? isSame = null;
        if (Old != null && Altered != null)
            isSame = Compare(Old, Altered);

        if (isSame.HasValue)
        {
            bool newBool = isSame.Value;

            if (newBool)
            {
                if (Altered != null)
                    label.Text = Altered.ToString();
            }
            else
            {
                label.ForeColor = System.Drawing.Color.Red;
                if (Altered != null)
                    label.Text = Altered.ToString();
            }
        }
        else
        {
            if (Altered != null)
                label.Text = Altered.ToString();
        }
    }

    private bool Compare<T>(T x, T y)
    {
        return x.Equals(y);
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        if (LevelId != 0 && String.IsNullOrEmpty(this.lblMessage.Text))
        {
            int errorCode = SaveData(true);
            MsgUtility.msg(editMode, errorCode, "Event Rule Approval", this, lblMessage, "Accepted");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "parent.tb_remove();", true);
        }
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        if (LevelId != 0 && String.IsNullOrEmpty(this.lblMessage.Text))
        {
            int errorCode = SaveData(false);
            MsgUtility.msg(editMode, errorCode, "Event Rule Approval", this, lblMessage, "Rejected");
        }
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "parent.tb_remove();", true);
        }
    }


    private int SaveData(Boolean isAccept)
    {
        EventRuleApprovalEnt eventRuleApproval = new EventRuleApprovalEnt();
        eventRuleApproval.EventRuleId = Id;
        eventRuleApproval.LevelId = LevelId;
        eventRuleApproval.Comments = this.txtComments.Text;

        if (isAccept)
            eventRuleApproval.Status = "Accepted";
        else
            eventRuleApproval.Status = "Rejected";

        return EventRuleApprovalDAL.SaveItem(eventRuleApproval, "I", OrderId);
    }


}