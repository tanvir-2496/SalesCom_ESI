using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class EventApprovalActivityEnt
    {
        public Int64 Id { get; set; }
        public Int32 EventId { get; set; }
        public Int32 ApprovalLevelId { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }

        public EventApprovalActivityEnt() { }
        public EventApprovalActivityEnt(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt64(dr["Id"]); }
            if (dr["EventId"] != DBNull.Value) { this.EventId = Convert.ToInt32(dr["EventId"]); }
            if (dr["ApprovalLevelId"] != DBNull.Value) { this.ApprovalLevelId = Convert.ToInt32(dr["ApprovalLevelId"]); }
            if (dr["Status"] != DBNull.Value) { this.Status = Convert.ToInt32(dr["Status"]); }
            this.Comments = dr["Comments"] as String;
        }
    }
}
