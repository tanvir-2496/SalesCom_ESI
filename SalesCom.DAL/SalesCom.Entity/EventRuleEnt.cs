using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class EventRuleEnt
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

        public int Reportid { get; set; }
        public string Reportname { get; set; }

        public EventRuleEnt() { }

        public EventRuleEnt(DataRow dr)
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
            if (dr["Reportid"] != DBNull.Value) { this.Reportid = Convert.ToInt32(dr["Reportid"]); }
            this.Reportname = dr["Reportname"] as string;

        }
    }

    public class EventRule2 : EventRuleEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { set; get; }
    }
}
