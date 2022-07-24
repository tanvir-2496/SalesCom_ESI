using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class EventRuleApprovalEnt
    {
        public Int64 EventApprovalId { get; set; }
        public Int64 EventRuleId { get; set; }
        public Int32 FlowId { get; set; }
        public Int32 LevelId { get; set; }
        public Int32 CycleId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }

        public EventRuleApprovalEnt() { }
        public EventRuleApprovalEnt(DataRow dr)
        {
            if (dr["EventApprovalId"] != DBNull.Value) { this.EventApprovalId = Convert.ToInt64(dr["EventApprovalId"]); }
            if (dr["EventRuleId"] != DBNull.Value) { this.EventRuleId = Convert.ToInt64(dr["EventRuleId"]); }
            if (dr["FlowId"] != DBNull.Value) { this.FlowId = Convert.ToInt32(dr["FlowId"]); }
            if (dr["LevelId"] != DBNull.Value) { this.LevelId = Convert.ToInt32(dr["LevelId"]); }
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.Status = dr["Status"] as String;
            this.Comments = dr["Comments"] as String;
        }
    }
}
