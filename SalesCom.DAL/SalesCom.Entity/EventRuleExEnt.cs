using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{

    public class EventRuleExEnt
    {
        public int EventRuleID { get; set; }
        public int EventID { get; set; }
        public int SegmentID { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int AmountTypeID { get; set; }
        public string CommissionType { get; set; }
        public decimal CommissionValue { get; set; }
        public decimal MaxCommissionPerevent { get; set; }
        public int ValidationRuleID { get; set; }

        public string EventName { get; set; }
        public string SegmentName { get; set; }
        public string AmountTypeName { get; set; }
        public string CommissionTypeName { get; set; }
        public string ValidationName { get; set; }
        public int RuleGroupID { get; set; }
        public string RuleGroupName { get; set; }
        public string EventRuleName { get; set; }

        public Int32 Status { get; set; }
        public Int64 LastEventRuleExLogId { get; set; }



        public Int32 ApprovalFlowId { get; set; }
        public string ApprovalName { get; set; }
        public Int16 CurrentLevel { get; set; }
        public string ApprovalLevelName { get; set; }
        public string CurrentStatus { get; set; }
        public string Comments { get; set; }
        public Int32 ApprovalLevelId { get; set; }
        public Int32 UserId { get; set; }
        public Int16 OrderId { get; set; }

        public string ReportName { get; set; }

        public EventRuleExEnt() { }

        public EventRuleExEnt(DataRow dr)
        {
            if (dr["EventRuleID"] != DBNull.Value) { this.EventRuleID = Convert.ToInt32(dr["EventRuleID"]); }
            if (dr["EventID"] != DBNull.Value) { this.EventID = Convert.ToInt32(dr["EventID"]); }
            if (dr["SegmentID"] != DBNull.Value) { this.SegmentID = Convert.ToInt32(dr["SegmentID"]); }
            if (dr["MinAmount"] != DBNull.Value) { this.MinAmount = Convert.ToDecimal(dr["MinAmount"]); }
            if (dr["MaxAmount"] != DBNull.Value) { this.MaxAmount = Convert.ToDecimal(dr["MaxAmount"]); }
            if (dr["AmountTypeID"] != DBNull.Value) { this.AmountTypeID = Convert.ToInt32(dr["AmountTypeID"]); }
            this.CommissionType = dr["CommissionType"] as string;
            if (dr["CommissionValue"] != DBNull.Value) { this.CommissionValue = Convert.ToDecimal(dr["CommissionValue"]); }
            if (dr["MaxCommissionPerevent"] != DBNull.Value) { this.MaxCommissionPerevent = Convert.ToDecimal(dr["MaxCommissionPerevent"]); }
            if (dr["ValidationRuleID"] != DBNull.Value) { this.ValidationRuleID = Convert.ToInt32(dr["ValidationRuleID"]); }
            this.EventName = dr["EventName"] as string;
            this.SegmentName = dr["SegmentName"] as string;
            this.AmountTypeName = dr["AmountTypeName"] as string;
            this.CommissionTypeName = dr["CommissionTypeName"] as string;
            this.ValidationName = dr["ValidationName"] as string;
            if (dr["RULEGROUP"] != DBNull.Value) { this.RuleGroupID = Convert.ToInt32(dr["RULEGROUP"]); }
            this.RuleGroupName = dr["GROUPNAME"] as string;
            this.EventRuleName = dr["EventRuleName"] as string;
            if (dr["Status"] != DBNull.Value) { Status = Convert.ToInt16(dr["Status"]); }
            if (dr["LastEventRuleExLogId"] != DBNull.Value) { LastEventRuleExLogId = Convert.ToInt64(dr["LastEventRuleExLogId"]); }

            if (dr["CurrentLevel"] != DBNull.Value) { this.CurrentLevel = Convert.ToInt16(dr["CurrentLevel"]); }
            this.CurrentStatus = dr["CurrentStatus"] as String;
            this.Comments = dr["Comments"] as String;
            if (dr["ApprovalFlowId"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["ApprovalFlowId"]); }
            this.ApprovalName = dr["ApprovalName"] as String;
            if (dr["ApprovalLevelId"] != DBNull.Value) { this.ApprovalLevelId = Convert.ToInt32(dr["ApprovalLevelId"]); }
            this.ApprovalLevelName = dr["ApprovalLevelName"] as String;
            if (dr["UserId"] != DBNull.Value) { this.UserId = Convert.ToInt32(dr["UserId"]); }
            if (dr["OrderId"] != DBNull.Value) { this.OrderId = Convert.ToInt16(dr["OrderId"]); }
            this.ReportName = dr["ReportName"] as String;
        }
    }

}
